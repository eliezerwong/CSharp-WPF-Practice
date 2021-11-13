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

namespace GraduationHandout
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
        
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool isEverythingGood = true;

            //Validate
            if (string.IsNullOrWhiteSpace(txtFN.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid First Name");
            }

            if (string.IsNullOrWhiteSpace(txtLN.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid Last Name");
            }

            if (string.IsNullOrWhiteSpace(txtMajor.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid Major");
            }

            double gpa;

            if (double.TryParse(txtGPA.Text, out gpa) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid GPA");
            }

            int streetNumber, zipCode;

            if (int.TryParse(txtSNum.Text, out streetNumber) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid Street Number");
            }

            if (string.IsNullOrWhiteSpace(txtSName.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid Street Name");
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid City");
            }

            if (string.IsNullOrWhiteSpace(txtState.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid State");
            }

            if (int.TryParse(txtZip.Text, out zipCode) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("Enter a valid Zipcode");
            }

            //out app since issue
            if (isEverythingGood == false)
            {
                return;
            }

            Student student = new Student()
            {
                FirstName = txtFN.Text,
                LastName = txtLN.Text,
                GPA = gpa,
                Major = txtMajor.Text

            };
            student.SetAddress(streetNumber, txtSName.Text, txtState.Text, txtCity.Text, zipCode);

            lstStudent.Items.Add(student);

            txtFN.Clear();
            txtLN.Clear();
            txtMajor.Clear();
            txtGPA.Clear();
            txtSNum.Clear();
            txtSName.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZip.Clear();

        }
    }
}
