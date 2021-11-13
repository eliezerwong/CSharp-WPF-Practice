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

namespace Problem1
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

            var lines = File.ReadAllLines("car_sales (1).csv").Skip(1);

            foreach (var item in lines)
            {
                var pieces = item.Split(',');
                //vin,make,color,year,model,sale_price

                allSales.Add(new CarSales() 
                { 
                    vin = pieces[0], 
                    make = pieces[1], 
                    color = pieces[2], 
                    year = Convert.ToInt32(pieces[3]), 
                    model = pieces[4], 
                    sale_price = pieces[5]
                });
            }

            PopulateLst(allSales);
            ColorFilter();
            YearFilter();
        }

        private void UpdateDataWFilters()
        {
            if (cboColor.SelectedValue is null || cboGreater.SelectedValue is null || string.IsNullOrEmpty(txtYear.Text))
            {
                return;
            }

            List<CarSales> filteredSales;
            filteredSales = FilterColor(allSales);
            filteredSales = FilterYear(filteredSales);
            PopulateLst(filteredSales);
            lblTotal.Content = $"Total Items: {lstCars.Items.Count}";
        }

        private List<CarSales> FilterYear(List<CarSales> filteredSales)
        {
            List<CarSales> filtered = new List<CarSales>();

            //bool isValid = true;
            //int yr;
            //if (Int32.TryParse(txtYear.Text, out yr) == false)
            //{ ||
            //    isValid = false;
            //    MessageBox.Show("Enter Valid Year");
            //}
            //else if (isValid == true)
            //{
            //    yr = yr;
            //}

            foreach (var item in filteredSales)
            {
                if (cboGreater.SelectedIndex == 0)
                {
                    if (item.year == Convert.ToInt32(txtYear.Text))
                    {
                        filtered.Add(item);
                    }
                }
                else if (cboGreater.SelectedValue.ToString().ToLower() == "less than or equal to")
                {
                    if (item.year <= Convert.ToInt32(txtYear.Text))
                    {
                        filtered.Add(item);
                    }
                    
                }
                else if (cboGreater.SelectedValue.ToString().ToLower() == "greater than or equal to")
                {
                    if (item.year >= Convert.ToInt32(txtYear.Text))
                    {
                        filtered.Add(item);
                    }
                    
                }

                //if (item.year == Convert.ToInt32(txtYear.Text) && cboGreater.SelectedValue.ToString().ToLower() == "equal to")
                //{
                //    filtered.Add(item);
                //}
                //else if (item.year == Convert.ToInt32(txtYear.Text) &&
                //    cboGreater.SelectedValue.ToString().ToLower() == "less than or equal to")
                //{
                //    if (item.year <= Convert.ToInt32(txtYear.Text))
                //    {
                //        filtered.Add(item);
                //    }
                //}
                //else if (item.year == Convert.ToInt32(txtYear.Text) &&
                //    cboGreater.SelectedValue.ToString().ToLower() == "greater than or equal to")
                //{
                //    if (item.year >= Convert.ToInt32(txtYear.Text))
                //    {
                //        filtered.Add(item);
                //    }
                //}
            }

            return filtered;
        }

        private List<CarSales> FilterColor(List<CarSales> allSales)
        {
            List<CarSales> filteredSales = new List<CarSales>();

            foreach (var item in allSales)
            {
                if (cboColor.SelectedValue.ToString().ToLower() == "all")
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

        private void YearFilter()
        {
            cboGreater.Items.Add("Equal to");
            cboGreater.Items.Add("Less than or Equal to");
            cboGreater.Items.Add("Greater than or Equal to");
            cboGreater.SelectedIndex = 0;
        }

        private void ColorFilter()
        {
            cboColor.Items.Add("All");
            cboColor.SelectedIndex = 0;

            foreach (var item in allSales)
            {
                if (string.IsNullOrWhiteSpace(item.color) == true)
                {
                    return;
                }

                if (!cboColor.Items.Contains(item.color))
                {
                    cboColor.Items.Add(item.color);
                }
                
            }
        }

        private void PopulateLst(List<CarSales> allSales)
        {
            lstCars.Items.Clear();
            foreach (var item in allSales)
            {
                lstCars.Items.Add(item);
            }
        }

        private void cboColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWFilters();
        }

        private void cboGreater_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWFilters();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(lstCars.Items, Formatting.Indented);
            File.WriteAllText("Car_Sales.json", json);
        }

    }
}
