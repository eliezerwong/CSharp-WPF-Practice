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

namespace PracticeJsonPokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PokeInfo poke;
        bool showfront;
        public MainWindow()
        {
            InitializeComponent();

            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon").Result;

                PokeAllAPI result = JsonConvert.DeserializeObject<PokeAllAPI>(jsonData);

                foreach (var item in result.results)
                {
                    cboName.Items.Add(item);
                }
            }
        }

        private void cboName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultItem selectedPoke = (ResultItem)cboName.SelectedItem;

            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync(selectedPoke.url).Result;
                poke = JsonConvert.DeserializeObject<PokeInfo>(jsonData);

                txtHeight.Text = poke.height;
                txtWeight.Text = poke.weight;
                imgSprite.Source = new BitmapImage(new Uri(poke.sprites.front_default));
                showfront = true;
            }
        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {
            if (showfront == true)
            {
                imgSprite.Source = new BitmapImage(new Uri(poke.sprites.back_default));
                showfront = false;
            }
            else if (showfront == false)
            {
                imgSprite.Source = new BitmapImage(new Uri(poke.sprites.front_default));
                showfront = true;
            }
        }
    }
}
