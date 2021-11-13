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

namespace Problem1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TVShow> TVshows = new List<TVShow>();
        private char[] valuesToTrim = { ' ', '"' };
        public MainWindow()
        {
            InitializeComponent();

            //reads all lines of file less the 1st and save to var lines
            var lines = File.ReadAllLines("TV Show Data.txt").Skip(1);

            //can use for loop too
            foreach (var line in lines)
            {
                TVshows.Add(new TVShow(line));
            }

            PopulateLstBox(TVshows);
            PopulateRatingFilter();
            PopulateCountryFilter();
            PopulateLanguageFilter();
        }

        private void PopulateLanguageFilter()
        {
            cboLan.Items.Add("All");
            cboLan.SelectedIndex = 0;
            foreach (var show in TVshows)
            {
                var values = show.Language.Split(',');

                foreach (var val in values)
                {
                    //if Language (piece) for show in TVshows (list) is empty, skip 
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }

                    //otherwise, add the cleanedValue of Rated (piece) into the combobox if it doesnt contain it yet
                    string cleanedValue = val.Trim(valuesToTrim);
                    if (!cboLan.Items.Contains(cleanedValue))
                    {
                        cboLan.Items.Add(cleanedValue);
                    }
                }
            };
        }

        private void PopulateCountryFilter()
        {
            cboCountry.Items.Add("All");
            cboCountry.SelectedIndex = 0;
            foreach (var show in TVshows)
            {
                //split countries at , and save to values
                var values = show.Country.Split(',');
                
                foreach (var val in values)
                {
                    //if country (piece) for show in TVshows (list) is empty, skip 
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }

                    //otherwise, add the cleanedValue of Rated (piece) into the combobox if it doesnt contain it yet
                    string cleanedValue = val.Trim(valuesToTrim);
                    if (!cboCountry.Items.Contains(cleanedValue))
                    {
                        cboCountry.Items.Add(cleanedValue);
                    }
                }
            };
        }

        /// <summary>
        /// adding unique values of Rated into combo filter
        /// </summary>
        private void PopulateRatingFilter()
        {
            cboRating.Items.Add("All");
            cboRating.SelectedIndex = 0;
            foreach (var show in TVshows)
            {
                //if Rated (piece) for show in TVshows (list) is empty, skip 
                if (string.IsNullOrWhiteSpace(show.Rated))
                {
                    continue;
                }

                //otherwise, add the cleanedValue of Rated (piece) into the combobox if it doesnt contain it yet
                string cleanedValue = show.Rated.Trim();
                if (!cboRating.Items.Contains(cleanedValue))
                {
                    cboRating.Items.Add(cleanedValue);
                }
            };
        }

        /// <summary>
        /// Adds all shows from list of TVshows into lstbox
        /// </summary>
        /// <param name="tVShows"></param>
        private void PopulateLstBox(List<TVShow> tVShows)
        {
            lstShows.Items.Clear();

            foreach (var show in tVShows)
            {
                lstShows.Items.Add(show);
            }
        }

        private void cboRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void cboCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void cboLan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void UpdateDataForFilters()
        {
            if (cboRating.SelectedValue is null || cboCountry.SelectedValue is null || cboLan.SelectedValue is null)
            {
                return;
            }

            List<TVShow> filteredShows;
            filteredShows = FilterRating(TVshows);
            filteredShows = FilterCountry(filteredShows);
            filteredShows = FilterLanguage(filteredShows);

            PopulateLstBox(filteredShows);
        }

        private List<TVShow> FilterLanguage(List<TVShow> shows) 
        {
            string language = cboLan.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (language.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Language.Contains(language))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }
        private List<TVShow> FilterCountry(List<TVShow> shows)
        {
            string country = cboCountry.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (country.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Country.Contains(country))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }
        private List<TVShow> FilterRating(List<TVShow> shows)
        {
            string rating = cboRating.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (rating.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Rated.Contains(rating))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cboRating.SelectedIndex = 0;
            cboCountry.SelectedIndex = 0;
            cboLan.SelectedIndex = 0;
        }

        private void lstShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TVShow selectedshow = (TVShow)lstShows.SelectedItem;
            ShowDetailsWindow sdw = new ShowDetailsWindow();
            sdw.SetupWindow(selectedshow);
            sdw.ShowDialog();
        }
    }
}
