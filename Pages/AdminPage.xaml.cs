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
using TheatreBooking.Pages;

namespace TheatreBooking
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void btnSpectacle_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SpectaclePage());
        }

        private void btnAfisha_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AfishaPage());
        }

        private void btnActor_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ActorPage());
        }

        private void btnGenre_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GenrePage());
        }

        private void btnSaal_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SaalPage());
        }
    }
}
