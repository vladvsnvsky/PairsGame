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

namespace Tema1
{
    /// <summary>
    /// Interaction logic for ImageSelectorUC.xaml
    /// </summary>
    public partial class ImageSelectorUC : UserControl
    {
        public event EventHandler<BitmapImage> ImageSelected;

        string currentPath;
        int currentPathIndex;

        List<string> paths = new List<string>
        {
            "D://FACULTATE//Facultate//An_2_sem_2//MVP_MediiVisualeDeProgramare//PairsGame//Tema1//Assets//Images//image1.png",
            "D://FACULTATE//Facultate//An_2_sem_2//MVP_MediiVisualeDeProgramare//PairsGame//Tema1//Assets//Images//image2.png",
            "D://FACULTATE//Facultate//An_2_sem_2//MVP_MediiVisualeDeProgramare//PairsGame//Tema1//Assets//Images//image3.png",
            "D://FACULTATE//Facultate//An_2_sem_2//MVP_MediiVisualeDeProgramare//PairsGame//Tema1//Assets//Images//image4.png",
            "D://FACULTATE//Facultate//An_2_sem_2//MVP_MediiVisualeDeProgramare//PairsGame//Tema1//Assets//Images//image5.png",
            "D://FACULTATE//Facultate//An_2_sem_2//MVP_MediiVisualeDeProgramare//PairsGame//Tema1//Assets//Images//image6.png"
        };

        public ImageSelectorUC()
        {
            InitializeComponent();
            currentPathIndex = 0;
            currentPath = paths[currentPathIndex];
            ImageSource imageSource = new BitmapImage(new Uri(currentPath));
            CurrentImageSelected.Source = imageSource;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPathIndex < paths.Count() - 1)
                currentPathIndex++;
            else currentPathIndex = 0;

            currentPath = paths[currentPathIndex];
            ImageSource imageSource = new BitmapImage(new Uri(currentPath));
            CurrentImageSelected.Source = imageSource;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPathIndex > 0)
                currentPathIndex--;
            else currentPathIndex = paths.Count()-1;

            currentPath = paths[currentPathIndex];
            ImageSource imageSource = new BitmapImage(new Uri(currentPath));
            CurrentImageSelected.Source = imageSource;
        }
    }
}
