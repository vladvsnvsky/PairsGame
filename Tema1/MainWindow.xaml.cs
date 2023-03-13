using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ListBoxData();
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

    public class ListBoxData
    {

        FileSystemWatcher fileWatcher = new FileSystemWatcher(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\");

        public ObservableCollection<string> ListOfItems { get; set; }

        public ListBoxData()
        {
            

            fileWatcher = new FileSystemWatcher(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\");

            fileWatcher.NotifyFilter = NotifyFilters.Attributes
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.FileName
                                    | NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Security
                                    | NotifyFilters.Size;

            fileWatcher.Changed += OnChanged;
            //fileWatcher.Created += OnCreated;
            //fileWatcher.Deleted += OnDeleted;
            //fileWatcher.Renamed += OnRenamed;
            //fileWatcher.Error += OnError;

            fileWatcher.Filter = "*.xml";
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();


            var playersList = XMLController.DeserializePlayersFromXmlFile(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");

            //this.ListOfItems.Clear();
            ListOfItems = new ObservableCollection<string>();

            foreach (Player p in playersList.Players)
            {
                ListOfItems.Add(p.Name);
            }

        }


        private void OnChanged(object sender, FileSystemEventArgs e)
        { 
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                //this.ListOfItems.Clear();

                //var playersList = XMLController.DeserializePlayersFromXmlFile(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");

                //foreach (Player p in playersList.Players)
                //{
                //    ListOfItems.Add(p.Name);
                //}
            }
            ListOfItems = new ObservableCollection<string>();

            var playersList = XMLController.DeserializePlayersFromXmlFile(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");

            foreach (Player p in playersList.Players)
            {
                ListOfItems.Add(p.Name);
            }
            Console.WriteLine($"Changed: {e.FullPath}");
        }
    }

}
