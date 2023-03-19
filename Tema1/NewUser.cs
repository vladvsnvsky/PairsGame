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
using System.Windows.Shapes;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        //private ObservableCollection<string> list;

        private ListBoxData dataRef;

        public event EventHandler TextChanged;



        public NewUser(ListBoxData listBoxData)
        {
            InitializeComponent();
            
            dataRef = listBoxData;
            warning.Text = "Username must contan more than 3 characters!";
            warning.Foreground = Brushes.Orange;
            warning.Visibility = Visibility.Visible;
            //manageInput = new TextChangedEventHandler(OnChange());
            //textInput.TextChanged = manageInput;
            //this.list = listBoxData.listOfItems;

        }


        private void Close_clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddUser_clicked(object sender, RoutedEventArgs e)
        {
            dataRef.fileWatcher.EnableRaisingEvents = false;
            PlayersList currentList = XMLController.DeserializePlayersFromXmlFile(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");
            currentList.Players.Add(new Player { Name = textInput.Text, ProfilePicturePath = ImgSelector.currentPath});
            //list.Add(textInput.Text);
            XMLController.SerializePlayersToXmlFile(currentList, @"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");
            dataRef.fileWatcher.EnableRaisingEvents = true;
            dataRef.updateListBox();
            this.Close();
        }

        private void checkAvailability(object sender, TextChangedEventArgs e)
        {
            string text = textInput.Text;
            if (text.Length > 3)
                if (usernameAlreadyExists(text))
                {
                    warning.Text = "This username is already in use.";
                    warning.Foreground = Brushes.Red;
                    warning.Visibility = Visibility.Visible;
                }
                else
                {
                    warning.Text = "This username is valid";
                    warning.Foreground = Brushes.GreenYellow;
                    warning.Visibility = Visibility.Visible;
                }
            else
            {
                warning.Text = "Username must contan more than 3 characters!";
                warning.Foreground = Brushes.Orange;
                warning.Visibility = Visibility.Visible;
            }


        }

        private bool usernameAlreadyExists(string text)
        {
            
            foreach (var p in dataRef.playersList.Players)
            {
                if (p.Name == text)
                    return true;
            }

            return false;
        }
    }
}
