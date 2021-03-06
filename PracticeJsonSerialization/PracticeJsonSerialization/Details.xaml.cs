using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticeJsonSerialization
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Details()
        {
            InitializeComponent();
        }

        public void Info(Games game)
        {
            lblName.Content = game.name;
            lblPlatform.Content = game.platform;
            lblRelease.Content = game.release_date;
            lblMeta.Content = game.meta_score;
            lblUser.Content = game.user_review;
            txtSummary.Text = game.summary;
        }
    }
}
