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

namespace Problem2
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDog.Text) == true)
            {
                MessageBox.Show("Enter a type of dog!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string breed = txtDog.Text.Trim();

            if (breed.Contains(' ') == true)
            {
                var dogInfo = breed.Split(' ');
                string subBreed = dogInfo[0];
                string mainBreed = dogInfo[1];

                breed = $"{mainBreed}/{subBreed}";
            }

            string url = $"https://dog.ceo/api/breed/{breed}/images/random";

            DogApi dog = null;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    dog = JsonConvert.DeserializeObject<DogApi>(json);
                }
                else
                {
                    MessageBox.Show("Sorry no dog breed with that name");
                    txtDog.Clear();
                }
            }

            if (dog != null)
            {
                imgDog.Source = new BitmapImage(new Uri(dog.message));
            }
        }

        private void btnClose_Change(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
