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

namespace FulfilData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<Data>> allData = new Dictionary<string, List<Data>>();
        public MainWindow()
        {
            InitializeComponent();

            string state = "";

            var lines = File.ReadAllLines("fulfill.csv");
            foreach (var line in lines)
            {
                var pieces = line.Split(',');
                if (string.IsNullOrWhiteSpace(pieces[0]) == false)
                {
                    state = pieces[0];
                }

                if (!allData.ContainsKey(state))
                {
                    allData.Add(state, new List<Data>());
                }
                else
                {
                    allData[state].Add(new Data() { Gender = pieces[1], Mean = pieces[2], N = pieces[3] });
                }
            }




        }
    }
}
