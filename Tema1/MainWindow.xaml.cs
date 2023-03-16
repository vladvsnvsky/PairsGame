﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// 
    public partial class MainWindow : Window
    {
        private ListBoxData dataRef;
        public MainWindow()
        {
            InitializeComponent();

            deleteUserBtn.IsEnabled = false;
            playBtn.IsEnabled = false;

            dataRef= new ListBoxData();
            DataContext = dataRef;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = playersListBox.SelectedItem;
            var selectedIndex = playersListBox.SelectedIndex;
            if(selectedItem!=null && selectedIndex != -1)
            {
                deleteUserBtn.IsEnabled = true;
                playBtn.IsEnabled = true;
            }
        }

        private void leftArrowBtn_clicked(object sender, RoutedEventArgs e)
        {

        }

        private void rightArrowBtn_clicked(object sender, RoutedEventArgs e)
        {

        }

        private void newUserBtn_Click(object sender, RoutedEventArgs e)
        {
            NewUser n = new NewUser(DataContext as ListBoxData);
            n.Show();
        }

        private void playBtn_clicked(object sender, RoutedEventArgs e)
        {
            SetGameDimensionsWindow sgdw = new SetGameDimensionsWindow(new Player() { Name = "Alex", ProfilePicturePath = "test" });
            sgdw.Show();
            //GameWindow game_window = new GameWindow();
            //game_window.Show();
        }

        private void deleteUserBtn_Click(object sender, RoutedEventArgs e)
        {
            dataRef.fileWatcher.EnableRaisingEvents = false;
            var selectedItem = playersListBox.SelectedItem;
            var selectedIndex = playersListBox.SelectedIndex;
            PlayersList currentList = XMLController.DeserializePlayersFromXmlFile(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");
            currentList.Players.RemoveAt(selectedIndex);
            XMLController.SerializePlayersToXmlFile(currentList, @"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");
            dataRef.fileWatcher.EnableRaisingEvents = true;
            dataRef.updateListBox();
        }
    }

    public class ListBoxData: INotifyPropertyChanged
    {

        public FileSystemWatcher fileWatcher = new FileSystemWatcher(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\");

        public ObservableCollection<string> listOfItems;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> ListOfItems {
            get { return listOfItems; }
            set
            {
                if (listOfItems != value)
                {
                    listOfItems = value;
                    OnPropertyChanged(nameof(ListOfItems));
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

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
            listOfItems = new ObservableCollection<string>();

            foreach (Player p in playersList.Players)
            {
                listOfItems.Add(p.Name);
            }

        }

        public void updateListBox()
        {
            ListOfItems = new ObservableCollection<string>();

            var playersList = XMLController.DeserializePlayersFromXmlFile(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");

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

        public void deleteItem(int index)
        {
            this.listOfItems.Remove(this.listOfItems[index]);
        }
    }
}