using System;
using System.Collections.Generic;
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

namespace PracticeJsonChuckNorris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cboCategory.Items.Add("All");
            cboCategory.SelectedIndex = 0;

            using (var client = new HttpClient())
            {
                string catURL = "https://api.chucknorris.io/jokes/categories";
                
                string json = client.GetStringAsync(catURL).Result;
                var results = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (var item in results)
                {
                    cboCategory.Items.Add(item);
                }
            }
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            string category = cboCategory.SelectedItem.ToString();
            string jokeURL = $"https://api.chucknorris.io/jokes/random?category={category}";


            using (var client = new HttpClient())
            {
                var joke = JsonConvert.DeserializeObject<Joke>(client.GetStringAsync(jokeURL).Result);

                txtJoke.Text = joke.value;
            }
        }
    }
}
