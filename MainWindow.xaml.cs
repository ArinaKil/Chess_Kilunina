using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chess_Kilunina.Classes;

namespace Chess_Kilunina
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Pawn> Pawns = new List<Pawn>();
        public List<Rook> Rooks = new List<Rook>();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;

            for (int i = 0; i <= 7; i++)
            {
                Pawns.Add(new Pawn(i, 1, false));
                Pawns.Add(new Pawn(i, 6, true));
            }

            Rooks.Add(new Rook(0, 0, false));
            Rooks.Add(new Rook(7, 0, false));
            Rooks.Add(new Rook(0, 7, true));
            Rooks.Add(new Rook(7, 7, true));

            CreateFigures();
        }

        public void CreateFigures()
        {
            foreach (Pawn Pawn in Pawns)
            {
                Pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                if (Pawn.Black)
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn (black).png")));
                else
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn.png")));
                Grid.SetColumn(Pawn.Figure, Pawn.X);
                Grid.SetRow(Pawn.Figure, Pawn.Y);
                Pawn.Figure.MouseDown += Pawn.SelectFigure;
                gameBoard.Children.Add(Pawn.Figure);
            }


            foreach (Rook rook in Rooks)
            {
                rook.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                if (rook.Black)
                    rook.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Rook (black).png")));
                else
                    rook.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Rook.png")));
                Grid.SetColumn(rook.Figure, rook.X);
                Grid.SetRow(rook.Figure, rook.Y);
                rook.Figure.MouseDown += rook.SelectFigure;
                gameBoard.Children.Add(rook.Figure);
            }
        }

        private void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Tile = sender as Grid;
            int X = Grid.GetColumn(Tile);
            int Y = Grid.GetRow(Tile);

            Pawn SelectPawn = MainWindow.init.Pawns.Find(x => x.Select == true);
            if (SelectPawn != null)
            {
                SelectPawn.Transform(X, Y);
                return;
            }

            Rook SelectRook = MainWindow.init.Rooks.Find(x => x.Select == true);
            if (SelectRook != null)
            {
                SelectRook.Transform(X, Y);
            }
        }

        public void OnSelect(Pawn pawn)
        {
            foreach (Pawn Pawn in Pawns)
                if (Pawn != pawn)
                    if (Pawn.Select)
                        Pawn.SelectFigure(null, null);

        }

        public void OnSelect(Rook rook)
        {
            foreach (Rook Rook in Rooks)
                if (Rook != rook)
                    if (Rook.Select)
                        Rook.SelectFigure(null, null);

        }
    }
}
