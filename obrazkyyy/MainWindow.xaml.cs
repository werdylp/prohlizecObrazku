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
using System.IO;


namespace obrazkyyy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<string> paths = new List<string>();
        Image myImage;
        int index = 0;
        public MainWindow()
        {
            InitializeComponent();
            GetUris(@"C:\Users\21ib03_cerna\source\repos\obrazkyyy\obrazkyyy\Images");
            myImage = new Image();
            nextbtn.Click += async (s, e) =>
            {
                await nextImg();
            };
            previousbtn.Click += async (s, e) =>
            {
                await previousImg();
            };

        }


        private void GetUris(string path)
        {
            foreach(string s in Directory.GetFiles(@path))
            {
                paths.Add(s);
            }
        }




        private async Task nextImg()
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            if ((index + 1) > paths.Count)
                index = 0;


            bitmap.UriSource = new Uri(paths[index]);

            bitmap.EndInit();
            Pic.Source = bitmap;
            index++;
        }
        private async Task previousImg()
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            if ((index - 1) == -1)
                index = paths.Count-1;
            bitmap.UriSource = new Uri(paths[index]);
            bitmap.EndInit();
            Pic.Source = bitmap;
            index--;
        }
    }
}
