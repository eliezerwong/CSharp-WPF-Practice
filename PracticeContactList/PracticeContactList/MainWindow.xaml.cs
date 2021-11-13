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

namespace PracticeContactList
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
                string[] pieces = line.Split('|');
                Contact c = new Contact()
                //{ FirstName = pieces[1], LastName = pieces[2], Email = pieces[3], Photo = pieces[4]}
                    ;
                c.FirstName = pieces[1];
                c.LastName = pieces[2];
                c.Email = pieces[3];
                c.Photo = pieces[4];

                lstContacts.Items.Add(c);
            }


        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Contact selectedContact = (Contact)lstContacts.SelectedItem;
            txtFName.Text = selectedContact.FirstName;
            txtLName.Text = selectedContact.LastName;
            txtEmail.Text = selectedContact.Email;

            imgPhoto.Source = new BitmapImage(new Uri(selectedContact.Photo));
        }
    }
}
