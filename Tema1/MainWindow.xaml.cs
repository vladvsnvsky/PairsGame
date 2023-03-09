using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Tema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<string> users = new List<string>() { "Corina", "Mama", "Simona", "Stefania", "Stefy" };
        public MainWindow()
        {
            //this.Resources.Add("usersList", users);
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void leftArrowBtn_clicked(object sender, RoutedEventArgs e)
        {

        }

        private void rightArrowBtn_clicked(object sender, RoutedEventArgs e)
        {

        }

        private void newUserBtn_Click(object sender, RoutedEventArgs e)
        {
            NewUser n = new NewUser();
            n.Show();
           
        }

        private void playBtn_clicked(object sender, RoutedEventArgs e)
        {
            GameWindow game_window = new GameWindow();
            game_window.Show();
        }
    }

}
