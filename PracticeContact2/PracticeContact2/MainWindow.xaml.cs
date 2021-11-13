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

namespace PracticeContact2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("contacts.txt").Skip(1);

            foreach (var line in lines)
            {
                var pieces = line.Split('|');
                Contact c = new Contact() { Id = pieces[0], FirstName = pieces[1], LastName = pieces[2], Email = pieces[3], Photo = pieces[4]};

                lstContacts.Items.Add(c);
            }
        }

        private void lstContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedC = (Contact)lstContacts.SelectedItem;
            txtFName.Text = selectedC.FirstName;
            txtLName.Text = selectedC.LastName;
            txtEmail.Text = selectedC.Email;

            imgPhoto.Source = new BitmapImage(new Uri(selectedC.Photo));
        }
    }
}
