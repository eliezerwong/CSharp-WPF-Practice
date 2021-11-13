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

namespace TVShowData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TVShow> tVShows = new List<TVShow>();
        private char[] toTrim = { ' ', '"' };
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("TV Show Data.txt").Skip(1);

            foreach (var line in lines)
            {
                var pieces = line.Split("\t");
                tVShows.Add(new TVShow()
                {
                    Actors =                pieces[1],
                    Awards =                pieces[2],
                    Country =               pieces[3],
                    Director =              pieces[4],
                    Genre =                 pieces[5],
                    Language =              pieces[6],
                    Plot =                  pieces[7],
                    Poster =                pieces[8],
                    Rated =                 pieces[9],
                    Released =              pieces[10],
                    RuntimeInMinutes =      pieces[11],
                    Title =                 pieces[12],
                    Type =                  pieces[13],
                    Writer =                pieces[14],
                    Year =                  pieces[15],
                    ImdbID =                pieces[16],
                    ImdbRating =            pieces[17],
                    ImdbVotes =             pieces[18],
                    TotalSeasons =          pieces[19],
                });
            }

            PopulateLst(tVShows);
            PopulateRatingFilter();
            PopulateCountryFilter();
            PopulateLanguageFilter();

        }

        private void UpdateDataWithFilters()
        {
            if (cboRating.SelectedValue is null || cboCountry.SelectedValue is null || cboLanguage.SelectedValue is null)
            {
                return;
            }

            List<TVShow> filteredShow;
            filteredShow = FilterRating(tVShows);
            filteredShow = FilterCountry(filteredShow);
            filteredShow = FilterLanguage(filteredShow);
            PopulateLst(filteredShow);
        }

        private List<TVShow> FilterLanguage(List<TVShow> filteredShow)
        {
            List<TVShow> filtered = new List<TVShow>();
            foreach (var show in filteredShow)
            {
                if (cboLanguage.SelectedValue.ToString().ToLower() == "all")
                {
                    filtered.Add(show);
                }
                else if (cboLanguage.SelectedValue.ToString() == show.Language)
                {
                    filtered.Add(show);
                }
            }
            return filtered;
        }

        private List<TVShow> FilterCountry(List<TVShow> filteredShow)
        {
            List<TVShow> filtered = new List<TVShow>();
            foreach (var show in filteredShow)
            {
                if (cboCountry.SelectedValue.ToString().ToLower() == "all")
                {
                    filtered.Add(show);
                }
                else if (cboCountry.SelectedValue.ToString() == show.Country)
                {
                    filtered.Add(show);
                }
            }
            return filtered;
        }

        private List<TVShow> FilterRating(List<TVShow> tVShows)
        {
            List<TVShow> filtered = new List<TVShow>();
            foreach (var show in tVShows)
            {
                if (cboRating.SelectedValue.ToString().ToLower() == "all")
                {
                    filtered.Add(show);
                }
                else if(cboRating.SelectedValue.ToString() == show.Rated)
                {
                    filtered.Add(show);
                }
            }
            return filtered;
        }

        private void PopulateLanguageFilter()
        {
            cboLanguage.Items.Add("All");
            cboLanguage.SelectedIndex = 0;

            foreach (var item in tVShows)
            {
                var value = item.Language.Split(',');
                foreach (var val in value)
                {
                    if (string.IsNullOrWhiteSpace(val) == true)
                    {
                        return;
                    }

                    string cleanValue = val.Trim(toTrim);
                    if (!cboLanguage.Items.Contains(cleanValue))
                    {
                        cboLanguage.Items.Add(cleanValue);
                    }
                }

            }
        }

        private void PopulateCountryFilter()
        {
            cboCountry.Items.Add("All");
            cboCountry.SelectedIndex = 0;

            foreach (var item in tVShows)
            {
                var value = item.Country.Split(',');
                foreach (var val in value)
                {
                    if (string.IsNullOrWhiteSpace(val) == true)
                    {
                        return;
                    }

                    string cleanValue = val.Trim(toTrim);
                    if (!cboCountry.Items.Contains(cleanValue))
                    {
                        cboCountry.Items.Add(cleanValue);
                    }
                }
                
            }
        }

        private void PopulateRatingFilter()
        {
            cboRating.Items.Add("All");
            cboRating.SelectedIndex = 0;

            foreach (var item in tVShows)
            {
                if (string.IsNullOrWhiteSpace(item.Rated) == true)
                {
                    return;
                }

                string cleanValue = item.Rated.Trim(toTrim);
                if (!cboRating.Items.Contains(cleanValue))
                {
                    cboRating.Items.Add(cleanValue);
                }
            }
        }

        private void PopulateLst(List<TVShow> tVShows)
        {
            lstTVShows.Items.Clear();
            foreach (var item in tVShows)
            {
                lstTVShows.Items.Add(item);
            };
        }

        private void cboRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWithFilters();
        }

        private void cboCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWithFilters();
        }

        private void cboLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWithFilters();
        }
    }
}
