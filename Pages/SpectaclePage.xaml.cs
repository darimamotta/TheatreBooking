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
    /// Interaction logic for SpectaclePage.xaml
    /// </summary>
    public partial class SpectaclePage : Page
    {
        public SpectaclePage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddSpectaclePage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removeSpectacle = GridSpectacle.SelectedItems.Cast<Spectacle>().ToList();
            if (removeSpectacle.Count > 0)
            {
                if (MessageBox.Show($"Vi hotite udlalit sleduzushie  {removeSpectacle.Count} elementi", "Udalenie",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    TheatreContext.Instance.Spectacles.RemoveRange(removeSpectacle);
                    TheatreContext.Instance.SaveChanges();
                    GridSpectacle.ItemsSource = TheatreContext.Instance.Spectacles.ToList();
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GridSpectacle.ItemsSource = TheatreContext.Instance.Spectacles.ToList();

            }
        }
    }
}
