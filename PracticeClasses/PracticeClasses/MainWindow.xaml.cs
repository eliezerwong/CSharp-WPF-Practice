using System;
using System.Collections.Generic;
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

namespace PracticeClasses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            
            if (string.IsNullOrWhiteSpace(txtManu.Text) == true)
            {
                isValid = false;
                MessageBox.Show("Enter valid Manu:");
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) == true)
            {
                isValid = false;
                MessageBox.Show("Enter valid Name:");
            }

            double inputPrice = 0;
            if (double.TryParse(txtPrice.Text, out inputPrice) == false)
            {
                isValid = false;
                MessageBox.Show("Enter valid Manu:");
            }

            if (string.IsNullOrWhiteSpace(txtImage.Text) == true)
            {
                isValid = false;
                MessageBox.Show("Enter valid Image:");
            }

            if (isValid == false)
            {
                return;
            }

            Toy toy = new Toy() { Manufacturer = txtManu.Text, Name = txtName.Text, Price = inputPrice, Image = txtImage.Text };
            
            lstToys.Items.Add(toy);
        }

        private void lstToys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy selectedToy = (Toy)lstToys.SelectedItem;
            MessageBox.Show(selectedToy.GetAisle());

            imgImage.Source = new BitmapImage(new Uri(selectedToy.Image));
        }
    }
}
