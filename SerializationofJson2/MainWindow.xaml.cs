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

namespace Problem2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<WinesAPI> allWines = new List<WinesAPI>();
        public MainWindow()
        {
            InitializeComponent();

            using (var client = new HttpClient())
            {
                List<WinesAPI> wines = JsonConvert.DeserializeObject<List<WinesAPI>>(
                    client.GetStringAsync("http://pcbstuou.w27.wh-2.com/webservices/3033/api/Wine/Reviews").Result);

                foreach (var item in wines)
                {
                    allWines.Add(item);
                }
            }


            PopulateLst(allWines);
            PopCboCountry();
        }

        private void UpdateDataWFilters()
        {
            if (cboCountry.SelectedValue is null )
            {
                return;
            }

            List<WinesAPI> filteredWines;
            filteredWines = FilterCountry(allWines);
            filteredWines = FilterPrice(filteredWines);
            PopulateLst(filteredWines);

            lblCount.Content = $"Count of Wines: {lstWines.Items.Count}";
        }

        private List<WinesAPI> FilterPrice(List<WinesAPI> filteredWines)
        {
            List<WinesAPI> filter = new List<WinesAPI>();

            foreach (var item in filteredWines)
            {
                if (string.IsNullOrEmpty(txtPrice.Text))
                {
                    filter.Add(item);
                }
                else if (Convert.ToDouble(item.price) <= Convert.ToDouble(txtPrice.Text))
                {
                    filter.Add(item);
                }
                
            }

            return filter;
        }

        private List<WinesAPI> FilterCountry(List<WinesAPI> allWines)
        {
            List<WinesAPI> filteredWines = new List<WinesAPI>();

            foreach (var item in allWines)
            {
                if (cboCountry.SelectedValue.ToString().ToLower() == "all")
                {
                    filteredWines.Add(item);
                }
                else if (cboCountry.SelectedValue.ToString() == item.country)
                {
                    filteredWines.Add(item);
                }
            }

            return filteredWines;
        }

        private void PopCboCountry()
        {
            cboCountry.Items.Add("All");
            cboCountry.SelectedIndex = 0;

            foreach (var item in allWines)
            {
                if (string.IsNullOrWhiteSpace(item.country) == true)
                {
                    return;
                }

                if (!cboCountry.Items.Contains(item.country))
                {
                    cboCountry.Items.Add(item.country);
                }
            };
        }

        private void PopulateLst(List<WinesAPI> w)
        {
            lstWines.Items.Clear();

            foreach (var item in w)
            {
                lstWines.Items.Add(item);
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataWFilters();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(lstWines.Items, Formatting.Indented);
            File.WriteAllText("wines.json", json);
        }
    }
}
