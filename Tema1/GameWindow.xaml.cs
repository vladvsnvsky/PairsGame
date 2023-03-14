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
using System.Windows.Shapes;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        Player player;
        List<Button> buttons;

        public int Nr_lines = 4;
        public int Nr_columns = 4;
        int Nr_buttons = 9;

        public bool unset = true;

        public GameWindow(Player _player, int lines=3, int columns=3)
        {
            InitializeComponent();

            player = _player;

            buttons = new List<Button>();

            Nr_lines = lines;
            Nr_columns = columns;

            matrixGrid.Rows = Nr_lines;
            matrixGrid.Columns = Nr_columns;
            Nr_buttons = Nr_lines * Nr_columns;


            for (int i = 0; i < Nr_lines; i++)
                for(int j=0; j<Nr_columns; j++)
                {
                    Button btn = new Button();
                    btn.Name = "image" + i + j;
                    btn.Content = "image"+i+j;
                    buttons.Add(btn);
                    matrixGrid.Children.Add(btn);
                }

            matrixGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            matrixGrid.VerticalAlignment = VerticalAlignment.Stretch;
            matrixGrid.Width = columns*70;
            matrixGrid.Height = lines*70;
        }

       

        private void cancelBtn_clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveBtn_clicked(object sender, RoutedEventArgs e)
        {
            //to do
        }
    }
}
