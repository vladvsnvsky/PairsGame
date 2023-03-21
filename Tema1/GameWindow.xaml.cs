using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Image[,] buttons;
        private GameController game;

        private ListBoxData dataRef;

        private Uri unknown_path = new Uri("Assets/Images/card_unknown.png", UriKind.Relative);

        private Uri[,] uris;

        public int Nr_lines = 4;
        public int Nr_columns = 4;

        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();

        Image selected1;
        private Tuple<int, int> selected1_coords;
        Image selected2;
        private Tuple<int, int> selected2_coords;
        int Nr_buttons = 9;

        public bool unset = true;

       

        public GameWindow(Player _player, ListBoxData listBoxData, int lines = 3, int columns = 3)
        {
            InitializeComponent();

            player = _player;

            profileImage.Source = new BitmapImage(new Uri(player.ProfilePicturePath, UriKind.Relative));
            usernameTextBlock.Text = player.Name;

            buttons = new Image[lines, columns];

            dataRef = listBoxData;

            Nr_lines = lines;
            Nr_columns = columns;
            int items = Nr_lines * Nr_columns;

            game = new GameController(Nr_lines, Nr_columns);

            

            matrixGrid.Rows = Nr_lines;
            matrixGrid.Columns = Nr_columns;
            Nr_buttons = Nr_lines * Nr_columns;

            t2.Interval = 1500;
            t2.Tick += new EventHandler(checkBoard);
            
            for (int i = 0; i < Nr_lines; i++)
                for(int j=0; j<Nr_columns; j++)
                {
                    Image image = new Image();
                    image.Source = new BitmapImage(unknown_path);
                    image.Stretch = Stretch.UniformToFill;
                    image.Tag = $"{i}{j}";
                    image.MouseDown += Image_MouseDown;

                    matrixGrid.Children.Add(image);
                    buttons[i, j] = image;
                }

            if (items % 2 != 0)
                buttons[Nr_lines - 1, Nr_columns - 1].Visibility = Visibility.Hidden;

            matrixGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            matrixGrid.VerticalAlignment = VerticalAlignment.Stretch;
            matrixGrid.Width = columns*70;
            matrixGrid.Height = lines*70;
        }

        public GameWindow(Player player1, ListBoxData listBoxData, Board playerSavedGame)
        {
            InitializeComponent();

            player = player1;
            profileImage.Source = new BitmapImage(new Uri(player.ProfilePicturePath, UriKind.Relative));
            usernameTextBlock.Text = player.Name;

            Nr_lines = playerSavedGame.Height;
            Nr_columns = playerSavedGame.Width;

            matrixGrid.Rows = Nr_lines;
            matrixGrid.Columns = Nr_columns;

            Nr_buttons = Nr_lines * Nr_columns;

            buttons = new Image[Nr_lines, Nr_columns];

            dataRef = listBoxData;

            t2.Interval = 1500;
            t2.Tick += new EventHandler(checkBoard);

            for (int i = 0; i < Nr_lines; i++)
            for (int j = 0; j < Nr_columns; j++)
            {
                Image image = new Image();
                image.Source = new BitmapImage(unknown_path);
                image.Stretch = Stretch.UniformToFill;
                image.Tag = $"{i}{j}";
                image.MouseDown += Image_MouseDown;

                matrixGrid.Children.Add(image);
                buttons[i, j] = image;
                if (playerSavedGame[i, j].Item1 == true)
                    buttons[i, j].Visibility = Visibility.Hidden;
            }

            matrixGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            matrixGrid.VerticalAlignment = VerticalAlignment.Stretch;
            matrixGrid.Width = Nr_columns * 70;
            matrixGrid.Height = Nr_lines * 70;

            game = new GameController(playerSavedGame);

            createUris();

            presentImagesForSeconds(2);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (selected1 == null)
            {
                selected1 = (Image)sender;
                string tag = selected1.Tag.ToString();
                int line = int.Parse(tag[0].ToString());
                int col = int.Parse(tag[1].ToString());
                selected1_coords = new Tuple<int, int>(line, col);
                ImageSource imageSource = new BitmapImage(uris[line,col]);
                buttons[line, col].Source = imageSource;
            }
            else
            {
                if (selected2 == null)
                {
                    selected2 = (Image)sender;
                    string tag = selected2.Tag.ToString();
                    int line = int.Parse(tag[0].ToString());
                    int col = int.Parse(tag[1].ToString());
                    selected2_coords = new Tuple<int, int>(line, col);
                    ImageSource imageSource = new BitmapImage(uris[line, col]);
                    buttons[line, col].Source = imageSource;
                    t2.Start();
                }
            }
        }

        private void checkBoard(object sender, EventArgs e)
        {
            t2.Stop();
            int line1 = selected1_coords.Item1;
            int line2 = selected2_coords.Item1;
            int col1 = selected1_coords.Item2;
            int col2 = selected2_coords.Item2;

            if (game.gameBoard[line1, col1].Item2 == game.gameBoard[line2, col2].Item2 && game.gameBoard[line1, col1].Item1==false && game.gameBoard[line2, col2].Item1==false)
            {
                game.mark(line1, col1, line2, col2);
                buttons[line1, col1].Visibility = Visibility.Hidden;
                buttons[line2, col2].Visibility = Visibility.Hidden;
            }
            else
            {
                ImageSource imageSource = new BitmapImage(unknown_path);
                buttons[line1, col1].Source = imageSource;
                buttons[line2, col2].Source = imageSource;
            }

            selected1 = null;
            selected2 = null;
            selected1_coords = null;
            selected2_coords = null;
        }

        private void cancelBtn_clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveBtn_clicked(object sender, RoutedEventArgs e)
        {
            dataRef.fileWatcher.EnableRaisingEvents = false;
            if (Nr_lines * Nr_columns % 2 != 0)
                game.gameBoard[Nr_lines - 1, Nr_columns - 1] = new Column(true, "test");
            PlayersList currentList = XMLController.DeserializePlayersFromXmlFile(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");
            for (int index = 0; index < currentList.Players.Count(); index++)
            {
                if (currentList.Players[index].Name == this.player.Name)
                    currentList.Players[index].savedGame = game.gameBoard;
                
            }
            XMLController.SerializePlayersToXmlFile(currentList, @"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml");
            dataRef.fileWatcher.EnableRaisingEvents = true;
        }

        private void continueBtn_clicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        
        private void newGameBtn_clicked(object sender, RoutedEventArgs e)
        {
            game = new GameController(Nr_lines, Nr_columns);
            game.startGame();
            createUris();

            presentImagesForSeconds(2);

        }

        private void presentImagesForSeconds(int seconds)
        {
            for (int i = 0; i < Nr_lines; i++)
            {
                for (int j = 0; j < Nr_columns; j++)
                {
                    if (uris[i, j] != null)
                    {
                        ImageSource imageSource = new BitmapImage(uris[i, j]);
                        buttons[i, j].Source = imageSource;
                    }
                }
            }

            t1.Interval = 2000; // specify interval time as you want
            t1.Tick += new EventHandler(hide_Images);
            t1.Start();
            
            
        }

        private void hide_Images(object sender, EventArgs e)
        {
            for (int i = 0; i < Nr_lines; i++)
            for (int j = 0; j < Nr_columns; j++)
            {
                ImageSource imageSource = new BitmapImage(unknown_path);
                buttons[i, j].Source = imageSource;
            }

            t1.Enabled = false;
        }


        private void createUris()
        {
            uris = new Uri[Nr_lines, Nr_columns];
            for (int i = 0; i < Nr_lines; i++)
            {
                for (int j = 0; j < Nr_columns; j++)
                {
                    if(game.gameBoard[i, j]!=null)
                    uris[i, j] = new Uri(game.gameBoard[i, j].Item2, UriKind.Relative);
                }
            }
        }

    }
}
