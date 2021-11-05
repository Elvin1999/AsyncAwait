using System;
using System.Collections.Generic;
using System.IO;
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

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int Count()
        {
            Thread.Sleep(5000);
            int count = 5000;
            return count;
        }

 

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task<int> task = new Task<int>(Count);
            //task.Start();
            //txtBlock.Text = "Process Starting . . .";
            //var result = await task;
            //txtBlock.Text += result;
            //txtBlock.Text += "Process Ended . . .";



            txtBlock.Text = "Process Starting . . .";
            var result =await GetDataAsync("myfile.txt.txt");
            txtBlock.Text += result;
            txtBlock.Text += "Process Ended . . .";



        }

        private async Task<string> GetDataAsync(string filename)
        {
            byte[] data = null;
            using (var fs=File.Open(filename,FileMode.OpenOrCreate))
            {
       
                data = new byte[fs.Length];
                await fs.ReadAsync(data, 0, (int)fs.Length);
            }
            return Encoding.UTF8.GetString(data);
        }


    }
}
