using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SetGameDimensionsWindow.xaml
    /// </summary>
    public partial class SetGameDimensionsWindow : Window
    {
        Player player;
        public SetGameDimensionsWindow(Player _player)
        {
            InitializeComponent();
            this.player = _player;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            int Nr_lines = Convert.ToInt32(linesInput.Text);
            int Nr_columns = Convert.ToInt32(colsInput.Text);
            GameWindow gw = new GameWindow(player, Nr_lines, Nr_columns);
            gw.Show();
            this.Close();
        }

        private void linesInputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (linesInput != null && colsInput != null)
            {
                string strLines = linesInput.Text;
                string strCols = colsInput.Text;

                bool checkResult1 = int.TryParse(strLines, out int intLines);
                bool checkResult2 = int.TryParse(strCols, out int intCols);
                if (checkResult1 == true && checkResult2 == true)
                {
                    startBtn.IsEnabled = true;
                }
                else startBtn.IsEnabled = false;
            }
            }

        private void colsInputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (linesInput != null && colsInput != null)
            {
                string strLines = linesInput.Text;
                string strCols = colsInput.Text;

                bool checkResult1 = int.TryParse(strLines, out int intLines);
                bool checkResult2 = int.TryParse(strCols, out int intCols);
                if (checkResult1 == true && checkResult2 == true)
                {
                    startBtn.IsEnabled = true;
                }
                else startBtn.IsEnabled = false;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
