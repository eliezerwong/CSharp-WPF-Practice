using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace PracticeGOT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GOTAPI> quote = new List<GOTAPI>();
        public MainWindow()
        {
            InitializeComponent();

            

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(quote, Formatting.Indented);
            File.WriteAllText("GOT.Json", json);
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                GOTAPI api = JsonConvert.DeserializeObject<GOTAPI>(client.GetStringAsync("https://got-quotes.herokuapp.com/quotes").Result);

                lblName.Content = api.character;
                txtQuote.Text = api.quote;
                quote.Add(api);
            }
        }
    }
}
