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

namespace PracticeHW4
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

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            string userInput = txtBreed.Text.Trim().ToLower();
            string breed = userInput;
            if (userInput.Contains(" "))
            {
                var pieces = userInput.Split(" ");
                breed = $"{pieces[1]}/{pieces[0]}";
            }

            string url = $"https://dog.ceo/api/breed/{breed}/images/random";

            Dog api = null;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = response.Content.ReadAsStringAsync().Result;
                    api = JsonConvert.DeserializeObject<Dog>(jsonData);
                }
                else
                {
                    MessageBox.Show("Input breed does not exist");
                    txtBreed.Clear();

                }

                if (api != null)
                {
                    imgDog.Source = new BitmapImage(new Uri(api.message));
                }

            }
        }
    }
}
