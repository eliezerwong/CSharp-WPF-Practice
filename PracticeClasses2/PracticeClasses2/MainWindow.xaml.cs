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

namespace PracticeClasses2
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

        private void lstToys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy selectedT = (Toy)lstToys.SelectedItem;
            MessageBox.Show(selectedT.GetAisle());

            imgBX.Source = new BitmapImage(new Uri(selectedT.Image));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtManu.Text) == true)
            {
                isValid = false;
                MessageBox.Show("Enter valid data");
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) == true)
            {
                isValid = false;
                MessageBox.Show("Enter valid data");
            }

            double price;

            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                isValid = false;
                MessageBox.Show("Enter valid data");
            }

            if (string.IsNullOrWhiteSpace(txtImage.Text) == true)
            {
                isValid = false;
                MessageBox.Show("Enter valid data");
            }

            if (isValid == false)
            {
                return;
            }

            Toy t = new Toy() { Manufacturer = txtManu.Text, Name = txtName.Text, Price = Convert.ToDouble(txtPrice.Text), Image = txtImage.Text };

            lstToys.Items.Add(t);
        }
    }
}
