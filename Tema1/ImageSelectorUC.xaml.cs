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
        //public event EventHandler<BitmapImage> ImageSelected;

        public Uri currentUri;

        public string currentPath;

        public int currentIndex;

        public List<string> paths = new List<string>
        {
            "Assets/Images/image1.png",
            "Assets/Images/image2.png",
            "Assets/Images/image3.png",
            "Assets/Images/image4.png",
            "Assets/Images/image5.png",
            "Assets/Images/image6.png"
        };

        private List<Uri> uris = new List<Uri>();

        public ImageSelectorUC()
        {
            InitializeComponent();

            foreach (var p in paths)
            {
                uris.Add(new Uri(p, UriKind.Relative));
            }

            currentIndex = 0;
            currentUri = uris[currentIndex];
            currentPath = paths[currentIndex];

            ImageSource imageSource = new BitmapImage(currentUri);
            CurrentImageSelected.Source = imageSource;
        }

        private void LeftButton_clicked(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
                currentIndex--;
            else currentIndex = paths.Count()-1;
            currentUri = uris[currentIndex];
            currentPath = paths[currentIndex];
            ImageSource imageSource = new BitmapImage(uris[currentIndex]);
            CurrentImageSelected.Source = imageSource;
        }

        private void RightButton_clicked(object sender, RoutedEventArgs e)
        {
            if (currentIndex < paths.Count()-1)
                currentIndex++;
            else currentIndex = 0;
            currentUri = uris[currentIndex];
            currentPath = paths[currentIndex];
            ImageSource imageSource = new BitmapImage(currentUri);
            CurrentImageSelected.Source = imageSource;
        }
    }
}
