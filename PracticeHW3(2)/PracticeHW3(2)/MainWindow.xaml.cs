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

namespace PracticeHW3_2_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TVShow> shows = new List<TVShow>();
        private char[] toTrim = { ' ', '"' };
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("TV Show Data.txt").Skip(1);

            foreach (var line in lines)
            {
                var pieces = line.Split("\t");

                shows.Add(new TVShow() 
                { 
                    Actors = pieces[1],
                    Awards = pieces[2],
                    Country = pieces[3],
                    Director = pieces[4],
                    Genre = pieces[5],
                    Language = pieces[6],
                    Plot = pieces[7],
                    Poster = pieces[8],
                    Rated = pieces[9],
                    Released = pieces[10],
                    RuntimeInMinutes = pieces[11],
                    Title = pieces[12],
                    Type = pieces[13],
                    Writer = pieces[14],
                    Year = pieces[15],
                    ImdbID = pieces[16],
                    ImdbRating = pieces[17],
                    ImdbVotes = pieces[18],
                    TotalSeasons = pieces[19],
                });

            }

            PopLst(shows);
            PopFilterRating();
            PopFilterCountry();
            PopFilterLan();
        }

        private void UpdateDataWithFilters()
        {
            if (cboRating.SelectedValue is null || cboCountry.SelectedValue is null || cboLan.SelectedValue is null)
            {
                return;
            }

            List<TVShow> filteredShow;
            filteredShow = FilterRating(shows);
            filteredShow = FilterCountry(filteredShow);
            filteredShow = FilterLan(filteredShow);

            PopLst(filteredShow);

        }

        private List<TVShow> FilterLan(List<TVShow> filteredShow)
        {
            List<TVShow> filter = new List<TVShow>();
            foreach (var show in filteredShow)
            {
                if (cboLan.SelectedValue.ToString().ToLower() == "all")
                {
                    filter.Add(show);
                }
                else if (cboLan.SelectedValue.ToString() == show.Language)
                {
                    filter.Add(show);
                }
            }

            return filter;
        }

        private List<TVShow> FilterCountry(List<TVShow> filteredShow)
        {
            List<TVShow> filter = new List<TVShow>();
            foreach (var show in filteredShow)
            {
                if (cboCountry.SelectedValue.ToString().ToLower() == "all")
                {
                    filter.Add(show);
                }
                else if (cboCountry.SelectedValue.ToString() == show.Country)
                {
                    filter.Add(show);
                }
            }

            return filter;
        }

        private List<TVShow> FilterRating(List<TVShow> shows)
        {
            List<TVShow> filter = new List<TVShow>();
            foreach (var show in shows)
            {
                if (cboRating.SelectedValue.ToString().ToLower() == "all")
                {
                    filter.Add(show);
                }
                else if (cboRating.SelectedValue.ToString() == show.Rated)
                {
                    filter.Add(show);
                }
            }

            return filter;
        }

        private void PopFilterLan()
        {
            cboLan.Items.Add("All");
            cboLan.SelectedIndex = 0;
            foreach (var show in shows)
            {
                var item = show.Language.Split(',');
                foreach (var i in item)
                {
                    if (string.IsNullOrWhiteSpace(i) == true)
                    {
                        return;
                    }

                    string cleanV = i.Trim(toTrim);
                    if (!cboLan.Items.Contains(cleanV))
                    {
                        cboLan.Items.Add(cleanV);
                    }
                }

            }
        }

        private void PopFilterCountry()
        {
            cboCountry.Items.Add("All");
            cboCountry.SelectedIndex = 0;
            foreach (var show in shows)
            {
                var item = show.Country.Split(',');
                foreach (var i in item)
                {
                    if (string.IsNullOrWhiteSpace(i) == true)
                    {
                        return;
                    }

                    string cleanV = i.Trim(toTrim);
                    if (!cboCountry.Items.Contains(cleanV))
                    {
                        cboCountry.Items.Add(cleanV);
                    }
                }
                
            }
        }

        private void PopFilterRating()
        {
            cboRating.Items.Add("All");
            cboRating.SelectedIndex = 0;

            foreach (var show in shows)
            {
                if (string.IsNullOrWhiteSpace(show.Rated) == true)
                {
                    return;
                }

                string cleanV = show.Rated.Trim(toTrim);
                if (!cboRating.Items.Contains(cleanV))
                {
                    cboRating.Items.Add(cleanV);
                }
            }
        }

        private void PopLst(List<TVShow> shows)
        {
            lstShow.Items.Clear();

            foreach (var show in shows)
            {
                lstShow.Items.Add(show);
            }
        }

        private void cboRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWithFilters();
        }

        private void cboCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWithFilters();
        }

        private void cboLan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWithFilters();
        }
    }
}
