using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace ConvertToMD5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog openFileDialog;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            SelectedFile.Content = openFileDialog.FileName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String Address = "http://" + IPAddress.Text + ":" + Port.Text + "/MD5/";
            using (WebClient client = new WebClient())
            {
                
                byte[] rawResponse = client.UploadFile(Address, openFileDialog.FileName);
                string hash = System.Text.Encoding.ASCII.GetString(rawResponse);
                Console.WriteLine("Remote Response: {0}", hash);
                MD5Hash.Content = hash;
            }
        }
    }
}
