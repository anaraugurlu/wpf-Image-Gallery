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

namespace wpf_Image_Gallery
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Image> Images { get; set; } = new ObservableCollection<Image>
        {
            new Image
            {
                ImagePath = "Images/1.png"
            },
            new Image
            {
                ImagePath = "Images/2.png"
            },
             new Image
            {
                ImagePath = "Images/3.png"
            }, new Image
            {
                ImagePath = "Images/4.png"
            }, new Image
            {
                ImagePath = "Images/5.png"
            }, new Image
            {
                ImagePath = "Images/6.png"
            }, new Image
            {
                ImagePath = "Images/7.png"
            }, new Image
            {
                ImagePath = "Images/8.png"
            }
        };


        int i = 1;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        //private void btnBack_Click(object sender, RoutedEventArgs e)
        //{
        //    i--;
        //    if (i < 1)
        //    {
        //        i = 8;
        //    }
        //    pic.Source = new BitmapImage(new Uri(@"Images/" + i + ".PNG", UriKind.Relative));
        //}

        //private void btnNext_Click(object sender, RoutedEventArgs e)
        //{
        //    i++;
        //    if (i > 8)
        //    {
        //        i = 1;
        //    }
        //    pic.Source = new BitmapImage(new Uri(@"Images/" + i + ".PNG", UriKind.Relative));
        //}

        //private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    var info = new Info();
        //    info.ShowDialog();

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

       

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            this.Resources["Size"] = 100.0;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Resources["Size"] = 300.0;


        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Resources["Size"] = 50.0;


        }


        private void Image_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = new Info();
           
            info.images = Images.ToList();
            info.index = (sender as ListBox).SelectedIndex;
            info.first = ((sender as ListBox).SelectedItem as Image).ImagePath;
            info.ShowDialog();
        }

        private void Image_DragEnter(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Images.Add(new Image { ImagePath = file[0] });
        }
    }
}
