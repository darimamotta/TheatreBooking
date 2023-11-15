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
    /// Interaction logic for PlaceBooking.xaml
    /// </summary>
    public partial class PlaceBooking : Page
    {
        private Afisha afisha;
        public PlaceBooking(Afisha afisha)
        {
            InitializeComponent();
            this.afisha = afisha;
            int n = afisha.Saal.Lines;
            int m = afisha.Saal.PlacesInLine;
            int size = (int)(wrap1.Width/m)-6;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    bool free = !afisha.Bookings.Any(x => x.Line == i + 1 && x.Place == j + 1);
                    TicketInfo info = new TicketInfo(i,j,free);
                }
            }

        }

    }
}
