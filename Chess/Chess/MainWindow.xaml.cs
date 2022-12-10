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
using ChessEngine.ViewModels;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CurrentGame _currentGame = new CurrentGame();
        
        public MainWindow()
        {
            InitializeComponent();
            CreatePromotionBox();
            DataContext = _currentGame;
        }

        private void ClickOnSquare(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            
            int x = b.Name[1] - '0';
            int y = b.Name[2] - '0';
            _currentGame.SelectSquare(x, y);
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            _currentGame.NewGame();
        }

        private void CreatePromotionBox()
        {
            PromotionBox.Items.Add("Queen");
            PromotionBox.Items.Add("Rook");
            PromotionBox.Items.Add("Bishop");
            PromotionBox.Items.Add("Knight");
        }

        private void HandlePromotion(object sender, RoutedEventArgs e)
        {
            _currentGame.ChangePromotionPiece(PromotionBox.SelectedItem.ToString());
        }
    }
}
