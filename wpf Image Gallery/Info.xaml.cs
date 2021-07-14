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
using System.Windows.Threading;

namespace wpf_Image_Gallery
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        int i = 1;
        public List<Image> images { get; set; }
        public int index { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
        public Info()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 1)
            {
                i = 8;
            }
            pic.Source = new BitmapImage(new Uri(@"Images/" + i + ".PNG", UriKind.Relative));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 8)
            {
                i = 1;
            }
            pic.Source = new BitmapImage(new Uri(@"Images/" + i + ".PNG", UriKind.Relative));
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            info.Close();
        }

        private void btnpause_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void btnplay_Click(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        } 
        
        
        
        
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (index + 1 < images.Count)
            {
                string ind = images[index + 1].ImagePath;
                int cn = index + 1;
                pic.Source = new BitmapImage(new Uri($@"{ind}", UriKind.RelativeOrAbsolute));
                index += 1;
            }
            else
            {
                index = 0;
                string ind = images[index].ImagePath;
                pic.Source = new BitmapImage(new Uri($@"{ind}", UriKind.RelativeOrAbsolute));

            }
        }
    }
}
