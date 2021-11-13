using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace FulfilData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<Data>> DataSet = new Dictionary<string, List<Data>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads";
            //This will get the path to their downloads directory,

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Comma Seperated Value documents (.csv)|*.csv";

            if (ofd.ShowDialog() == true)
            {
                PopulateData(ofd.FileName);

                PopulateListBox("Male", lstM);
                PopulateListBox("Female", lstF);
                PopulateListBox("Both", lstBoth);
                PopulateListBoxForMeanGreaterThan();

            }

        }

        private void PopulateListBox(string gender, ListBox lst)
        {
            double maxMean = DataSet["AL"][0].Mean;

            foreach (var item in DataSet.Keys)
            {
                foreach (var gend in DataSet[item])
                {
                    if (gender.ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean > maxMean)
                        {
                            maxMean = gend.Mean;
                        }
                    }
                }
            }

            foreach (var state in DataSet.Keys)
            {
                foreach (var gend in DataSet[state])
                {
                    if (gender.ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean == maxMean)
                        {
                            lst.Items.Add(state);
                            //switch (gender)
                            //{
                            //    case "male":
                            //        lstM.Items.Add(state);
                            //        break;
                            //    case "female":
                            //        lstF.Items.Add(state);
                            //        break;
                            //    case "both":
                            //        lstBoth.Items.Add(state);
                            //        break;

                            //}
                            
                        }
                    }
                }
            }
        }

        private void PopulateListBoxForMeanGreaterThan()
        {
            double mean = 8;

            foreach (var state in DataSet.Keys)
            {
                foreach (var gend in DataSet[state])
                {
                    if ("both".ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean >= mean)
                        {
                            lstOver8.Items.Add(state);
                           
                        }
                    }
                }
            }
        }

        private void PopulateData(string file)
        {
            var lines = File.ReadAllLines(file);
            //State  Gender  Mean  N=
            //AL     Male
            //       Female
            //       Both


            string state = "";
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var pieces = line.Split(',');
                if (string.IsNullOrWhiteSpace(pieces[0]) == false)
                {
                    state = pieces[0];

                }

                double mean;
                int n;

                if (double.TryParse(pieces[2], out mean) == false)
                {
                    continue;
                }

                if (int.TryParse(pieces[3], out n) == false)
                {
                    continue;
                }

                if (DataSet.ContainsKey(state) == false)
                {  
                    DataSet.Add(state, new List<Data>());

                }

                DataSet[state].Add(new Data()
                {
                    State = state,
                    Gender = pieces[1],
                    Mean = mean,
                    N = n
                });

            }
        }
    }
}
