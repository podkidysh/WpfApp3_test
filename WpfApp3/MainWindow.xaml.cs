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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] captchFile = new string[]
            {
                "Image/captch1.png" , "Image/captch2.png" , "Image/captch3.png"
            };
        string[] captchIsTrue = new string[]
            { 
                "A7C2" , "CBH1" , "5P34"
            };
        int captchInt = 0;
        bool capthc = false;
        int i = 0; // podschet popitok vhoda
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            captchInt = random.Next(0, captchFile.Length);
            Uri uri = new Uri(captchFile[captchInt], UriKind.RelativeOrAbsolute);
            BitmapImage bitmapImage = new BitmapImage(uri);
            imageCap.Source = bitmapImage;

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNameN.Text))
            {
                MessageBox.Show("vvedi imya");
                return;
            }
            if (capthc == false)
            {
                if (tbNameN.Text == "admin")
                    MessageBox.Show("yRa");
                else
                {
                    MessageBox.Show("Nevernoe imya");
                    capthc = true;
                    spCap.Visibility = Visibility.Visible;
                    return;
                }
            }

            if(capthc == true)
            {
                
                if (string.IsNullOrEmpty(tbName.Text))
                {
                    MessageBox.Show("vvwsite captch");
                    return;
                }
                if (tbNameN.Text == "admin" && tbName.Text == captchIsTrue[captchInt])
                {
                    MessageBox.Show("yRa");
                    spCap.Visibility = Visibility.Collapsed;
                    capthc = false;
                }
                else
                {
                    MessageBox.Show("Nevernie dannie");
                    Title = "Блокировка";
                    Thread.Sleep(10000);
                    Title = "Авторизация";
                    MainWindow_Loaded(sender, e);
                    return;

                }
            }
        }

        private void btnRefrash_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_Loaded(sender, e);
        }
    }
}
