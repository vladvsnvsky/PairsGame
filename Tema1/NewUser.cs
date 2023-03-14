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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();
            ImageSelectorUC imageSelectorUc = new ImageSelectorUC();

        }

        private void Close_clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddUser_clicked(object sender, RoutedEventArgs e)
        {
            PlayersList currentList = XMLController.DeserializePlayersFromXmlFile(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");
            currentList.Players.Add(new Player { Name = textInput.Text, ProfilePicturePath = "test" });
            XMLController.SerializePlayersToXmlFile(currentList, @"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");
            this.Close();
        }
    }
}
