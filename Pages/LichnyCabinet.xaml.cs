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
using TheatreBooking.Model;

namespace TheatreBooking.Pages
{
    /// <summary>
    /// Interaction logic for LichnyCabinet.xaml
    /// </summary>
    public partial class LichnyCabinet : Page
    {
        public LichnyCabinet()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            GridCabinet.ItemsSource = Manager.CurrentUser.Bookings.Select(t => t.Afisha).Distinct().ToList();


        }

        private void GridCabinet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Afisha afisha = GridCabinet.SelectedItem as Afisha;
            if (afisha != null)
            {
                var selectedBookings=Manager.CurrentUser.Bookings.Where(t => t.Afisha == afisha);
                bookedPlaces.Items.Clear();
                foreach (var book in selectedBookings)
                {
                    bookedPlaces.Items.Add($"Place {book.Place}th in line {book.Line}th");
                }
            }
        }
    }
}
