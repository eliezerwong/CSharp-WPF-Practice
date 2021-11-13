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

namespace PracticeEx1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GME> stockD = new List<GME>();
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("GME_stock.csv").Skip(1);

            foreach (var line in lines)
            {
                var piecces = line.Split(',');
                stockD.Add(new GME() { Date = piecces[0], OpenPrice = piecces[1], HighPrice = piecces[2], LowPrice = piecces[3], ClosePrice = piecces[4], Volume = piecces[5]});
            }

            PopulateLst(stockD);
            PopulateDayFilter();

        }

        private void UpdateDataWithFilter()
        {
            if (cboDate.SelectedItem is null)
            {
                return;
            }

            List<GME> filteredData;
            filteredData = FilterDate(stockD);
            PopulateLst(filteredData);
        }

        private List<GME> FilterDate(List<GME> stockD)
        {
            List<GME> filter = new List<GME>();
            foreach (var item in stockD)
            {
                if (cboDate.SelectedValue.ToString().ToLower() == "all")
                {
                    filter.Add(item);
                }
                else if (cboDate.SelectedValue.ToString() == item.Date)
                {
                    filter.Add(item);
                }
            }
            return filter;
        }

        private void PopulateDayFilter()
        {
            cboDate.Items.Add("All");
            cboDate.SelectedIndex = 0;
            foreach (var d in stockD)
            {
                if (string.IsNullOrWhiteSpace(d.Date) == true)
                {
                    return;
                }

                if (!cboDate.Items.Contains(d.Date))
                {
                    cboDate.Items.Add(d.Date);
                }
            }
        }

        private void PopulateLst(List<GME> stockD)
        {
            lstGME.Items.Clear();

            foreach (var d in stockD)
            {
                lstGME.Items.Add(d);
            }
        }

        private void cboDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataWithFilter();
        }

        private void lstGME_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GME selectedItem = (GME)lstGME.SelectedItem;
            txtMin.Text = selectedItem.LowPrice;
        }
    }
}
