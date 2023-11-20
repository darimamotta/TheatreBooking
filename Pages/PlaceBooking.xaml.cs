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
        private List<TicketInfo> ticketInfos =new List<TicketInfo>();
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
                    bool isBooked = afisha.Bookings.Any(x => x.Line == i + 1 && x.Place == j + 1);
                    TicketInfo info = new TicketInfo(i,j,isBooked);
                    ticketInfos.Add(info);
                    Rectangle rectangle = new Rectangle();
                    rectangle.Tag = info;
                    rectangle.Margin= new Thickness(3);
                    rectangle.Width = size;
                    rectangle.Height = size;
                    if (!isBooked)
                        rectangle.Fill = Brushes.Green;
                    else rectangle.Fill = Brushes.Red;
                    rectangle.MouseDown += Rectangle_MouseDown;
                    wrap1.Children.Add(rectangle);
                }
            }

        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;
            TicketInfo ticketInfo = rectangle.Tag as TicketInfo;
            if(!ticketInfo.IsBooked)
            {
                if(ticketInfo.IsChosenNow)
                {
                    rectangle.Fill= Brushes.Green;
                    ticketInfo.IsChosenNow = false;
                }
                else
                {
                    rectangle.Fill=Brushes.Yellow; 
                    ticketInfo.IsChosenNow = true;
                    
                }
                ShowBookedPlaces();
            }
        }

        private void ShowBookedPlaces()
        {
            var chosenPlaces = ticketInfos.Where(x => x.IsChosenNow);
            lstBox1.Items.Clear();
            foreach (var chosenPlace in chosenPlaces)
            {
                lstBox1.Items.Add($"You chose the place in {chosenPlace.Line}th line {chosenPlace.Seat}th seat");
            }
            var itogo = chosenPlaces.Count()*afisha.Spectacle.Price;
            BookBtn.Content = $"Stoimost itogo {itogo} rubles";

        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
