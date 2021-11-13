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

namespace PracticeRickMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = $"https://rickandmortyapi.com/api/character/?page=1";

            using (var client = new HttpClient())
            {
                while (url != null)
                {
                    string jsonData = client.GetStringAsync(url).Result;
                    CharactersAPI api = JsonConvert.DeserializeObject<CharactersAPI>(jsonData);

                    foreach (var item in api.results)
                    {
                        lstCharacters.Items.Add(item);
                    }

                    url = api.info.next;
                }
            }
        }

        private void lstCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Result selectedChara = (Result)lstCharacters.SelectedItem;
            txtName.Text = selectedChara.name;
            imgPhoto.Source = new BitmapImage(new Uri(selectedChara.image));
        }
    }
}
