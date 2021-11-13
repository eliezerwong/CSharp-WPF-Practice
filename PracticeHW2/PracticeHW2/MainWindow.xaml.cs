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

namespace Graduation_Handout
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
            
            ValidateString(txtFName.Text);
            ValidateString(txtLName.Text);
            ValidateString(txtMajor.Text);
            bool isValid = true;
            double output;
            if (Double.TryParse(txtGPA.Text, out output) == false)
            {
                isValid = false;
                MessageBox.Show("Please enter valid int");
            }


            int sNum, zip;
            if (Int32.TryParse(txtStNumber.Text, out sNum) == false)
            {
                isValid = false;
                MessageBox.Show("Please enter valid int");
            }
            ValidateString(txtStName.Text);
            ValidateString(txtState.Text);
            ValidateString(txtCity.Text);
            if (Int32.TryParse(txtZipCode.Text, out zip) == false)
            {
                isValid = false;
                MessageBox.Show("Please enter valid int");
            }

            if (isValid == false)
            {
                return;
            }

            Student s = new Student(txtFName.Text, txtLName.Text, txtMajor.Text, output);
            s.SetAddress(sNum, txtStName.Text, txtState.Text, txtCity.Text, zip);

            lstStudents.Items.Add(s);

            txtFName.Clear();
            txtLName.Clear();
            txtMajor.Clear();
            txtGPA.Clear();
            txtStNumber.Clear();
            txtStName.Clear();
            txtState.Clear();
            txtCity.Clear();
            txtZipCode.Clear();

        }

        private void ValidateString(string data)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(data) == true)
            {
                isValid = false;
                MessageBox.Show("Please enter valid string");
            }

            if (isValid == false)
            {
                return;
            }
        }
    }
}
