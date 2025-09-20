using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Chess_Kilunina.Classes
{
    public class Rook
    {
        public int X, Y;
        public bool Select, Black;
        public Grid Figure;

        public Rook(int X, int Y, bool Black)
        {
            this.X = X;
            this.Y = Y;
            this.Black = Black;
        }

        public void SelectFigure(object sender, MouseButtonEventArgs e)
        {
            MainWindow.init.OnSelect(this);
            if (Select)
            {
                if (Black)
                    Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Rook (black).png")));
                else
                    Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Rook.png")));
                Select = false;
            }
            else
            {
                Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Rook (select).png")));
                Select = true;
            }
        }

        public void Transform(int X, int Y)
        {
            if ((this.X == X && this.Y != Y) || (this.X != X && this.Y == Y))
            {
                Grid.SetColumn(this.Figure, X);
                Grid.SetRow(this.Figure, Y);
                this.X = X;
                this.Y = Y;
            }
            SelectFigure(null, null);
        }
    }
}
