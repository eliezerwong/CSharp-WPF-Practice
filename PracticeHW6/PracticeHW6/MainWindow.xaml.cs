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

namespace PracticeHW6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CarSales> allSales = new List<CarSales>();
        public MainWindow()
        {
            InitializeComponent();

            var line = File.ReadAllLines("car_sales (1).csv").Skip(1);
            //vin,make,color,year,model,sale_price

            foreach (var item in line)
            {
                var piece = item.Split(',');

                allSales.Add(new CarSales()
                {
                    vin = piece[0], make = piece[1], color = piece[2], year = piece[3], model = piece[4], sale_price = piece[5]
                });
            }

            PopulateLst(allSales);
            PopColorCbo();
            PopGreaterCbo();
        }

        public void UpdateDataWFilters()
        {
            if (cboColor.SelectedItem is null || cboGreater.SelectedItem is null || string.IsNullOrEmpty(txtYear.Text))
            {
                return;
            }

            List<CarSales> filteredSales;
            filteredSales = ColorFilter(allSales);
            filteredSales = YearFilter(filteredSales);
            PopulateLst(filteredSales);
            lblCount.Content = $"Count of Sales: {lstCars.Items.Count}";
        }

        private List<CarSales> YearFilter(List<CarSales> filteredSales)
        {
            List<CarSales> filter = new List<CarSales>();

            foreach (var item in filteredSales)
            {
                if (cboGreater.SelectedIndex == 0)
                {
                    if (Convert.ToInt32(item.year) == Convert.ToInt32(txtYear.Text))
                    {
                        filter.Add(item);
                    }
                }
                else if (cboGreater.SelectedIndex == 1)
                {
                    if (Convert.ToInt32(item.year) <= Convert.ToInt32(txtYear.Text))
                    {
                        filter.Add(item);
                    }
                }
                else if (cboGreater.SelectedIndex == 2)
                {
                    if (Convert.ToInt32(item.year) >= Convert.ToInt32(txtYear.Text))
                    {
                        filter.Add(item);
                    }
                }
            }
            return filter;
        }

        private List<CarSales> ColorFilter(List<CarSales> allSales)
        {
            List<CarSales> filteredSales = new List<CarSales>();

            foreach (var item in allSales)
            {
                if (cboColor.SelectedIndex == 0)
                {
                    filteredSales.Add(item);
                }
                else if (cboColor.SelectedValue.ToString() == item.color)
                {
                    filteredSales.Add(item);
                }
            }
            return filteredSales;
        }

        private void PopGreaterCbo()
        {
            cboGreater.Items.Add("Equals to");
            cboGreater.Items.Add("Less than or Equals to");
            cboGreater.Items.Add("Greater than or Equals to");
        }

        private void PopColorCbo()
        {
            cboColor.Items.Add("All");
            cboColor.SelectedIndex = 0;
            foreach (var item in allSales)
            {
                if (string.IsNullOrEmpty(item.color) == true)
                {
                    return;
                }

                if (!cboColor.Items.Contains(item.color))
                {
                    cboColor.Items.Add(item.color);
                }
            };
        }

        private void PopulateLst(List<CarSales> allSales)
        {
            lstCars.Items.Clear();

            foreach (var item in allSales)
            {
                lstCars.Items.Add(item);
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataWFilters();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string jsonData = JsonConvert.SerializeObject(lstCars.Items, Formatting.Indented);
            File.WriteAllText("car_sales.json", jsonData);
        }
    }
}
