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

namespace ChessApp.Views
{
    /// <summary>
    /// Interaction logic for HumanVsHumanPage.xaml
    /// </summary>
    public partial class HumanVsHumanPage : Page
    {
        public HumanVsHumanPage()
        {
            InitializeComponent();

            SolidColorBrush lightSquareColor = new SolidColorBrush(new Color() { A = 255, R = 240, G = 217, B = 181});
            SolidColorBrush darkSquareColor = new SolidColorBrush(new Color() { A = 255, R = 181, G = 135, B = 99 });

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    SolidColorBrush squareColor = (i + j) % 2 == 0 ? lightSquareColor : darkSquareColor;

                    Rectangle squareRectangle = new Rectangle();
                    squareRectangle.Fill = squareColor;

                    Grid squareGrid = new Grid();
                    squareGrid.Children.Add(squareRectangle);

                    if (j == 7)
                    {
                        TextBlock fileTextBlock = new TextBlock();
                        fileTextBlock.Text = (8 - i).ToString();
                        fileTextBlock.FontWeight = FontWeights.Bold;
                        fileTextBlock.Margin = new Thickness(0.0, 3.0, 3.0, 0.0);
                        fileTextBlock.VerticalAlignment = VerticalAlignment.Top;
                        fileTextBlock.HorizontalAlignment = HorizontalAlignment.Right;
                        fileTextBlock.Foreground = (squareColor == lightSquareColor) ? darkSquareColor : lightSquareColor;

                        squareGrid.Children.Add(fileTextBlock);
                    }

                    if (i == 7)
                    {
                        TextBlock rankTextBlock = new TextBlock();
                        rankTextBlock.Text = ((char)('a' + j)).ToString();
                        rankTextBlock.FontWeight = FontWeights.Bold;
                        rankTextBlock.Margin = new Thickness(3.0, 0.0, 0.0, 3.0);
                        rankTextBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        rankTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                        rankTextBlock.Foreground = (squareColor == lightSquareColor) ? darkSquareColor : lightSquareColor;

                        squareGrid.Children.Add(rankTextBlock);
                    }

                    Image checkEffectImage = new Image();
                    checkEffectImage.Visibility = Visibility.Hidden; // TODO: Remember this
                    checkEffectImage.Source = new BitmapImage(new Uri("/ChessApp;component/Resources/Pieces/Check.png", UriKind.Relative));
                    squareGrid.Children.Add(checkEffectImage);

                    Image pieceImage = new Image();
                    pieceImage.Source = new BitmapImage(new Uri("/ChessApp;component/Resources/Pieces/WhiteKnight.png", UriKind.Relative));
                    squareGrid.Children.Add(pieceImage);

                    Board.Children.Add(squareGrid);
                }
            }
        }
    }
}
