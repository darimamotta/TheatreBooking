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
    /// Interaction logic for SaalPage.xaml
    /// </summary>
    public partial class SaalPage : Page
    {
        public SaalPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddSaalePage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removeSaal = GridSaal.SelectedItems.Cast<Saal>().ToList();
            if (removeSaal.Count > 0)
            {
                if (MessageBox.Show($"Vi hotite udlalit sleduzushie  {removeSaal.Count} elementi", "Udalenie",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    TheatreContext.Instance.Saal.RemoveRange(removeSaal);
                    TheatreContext.Instance.SaveChanges();
                    GridSaal.ItemsSource = TheatreContext.Instance.Saal.ToList();
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GridSaal.ItemsSource = TheatreContext.Instance.Saal.ToList();

            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Saal saal = (sender as Button).DataContext as Saal;
            Manager.MainFrame.Navigate(new AddSaalePage(saal));
        }
    }
}
