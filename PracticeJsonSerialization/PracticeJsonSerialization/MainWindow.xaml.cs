using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;

namespace PracticeJsonSerialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Games> allGames = new List<Games>();
        
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("all_games (1).csv").Skip(1);

            foreach (var item in lines)
            {
                var pieces = item.Split(',');

                allGames.Add(new Games() 
                { 
                    name = pieces[0], 
                    platform = pieces[1], 
                    release_date = pieces[2], 
                    summary = pieces[3], 
                    meta_score = pieces[4], 
                    user_review = pieces[5] 
                });
            }

            PopulateLst(allGames);
            PopCboPlat();
        }

        public void UpdateDataWFilters()
        {
            if (cboPlatform is null)
            {
                return;
            }

            List<Games> filteredGames;
            filteredGames = FilterPlatform(allGames);
            PopulateLst(filteredGames);

        }

        private List<Games> FilterPlatform(List<Games> allGames)
        {
            List<Games> filter = new List<Games>();
            foreach (var item in allGames)
            {
                if (cboPlatform.SelectedIndex == 0)
                {
                    filter.Add(item);
                }
                else if (cboPlatform.SelectedValue.ToString() == item.platform)
                {
                    filter.Add(item);
                }
            }
            return filter;
        }

        private void PopCboPlat()
        {
            cboPlatform.Items.Add("All");
            cboPlatform.SelectedIndex = 0;

            foreach (var item in allGames)
            {
                if (string.IsNullOrEmpty(item.platform))
                {
                    return;
                }

                if (!cboPlatform.Items.Contains(item.platform))
                {
                    cboPlatform.Items.Add(item.platform);
                }
            }
        }

        private void PopulateLst(List<Games> allGames)
        {
            lstGames.Items.Clear();
            foreach (var item in allGames)
            {
                lstGames.Items.Add(item);
            }
        }

        private void cboPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWFilters();
        }

        private void lstGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Games selectedGame = (Games)lstGames.SelectedItem;
            Details info = new Details();
            info.Info(selectedGame);
            info.ShowDialog();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(lstGames.Items, Formatting.Indented);
            File.WriteAllText("games.json", json);
        }
    }
}
