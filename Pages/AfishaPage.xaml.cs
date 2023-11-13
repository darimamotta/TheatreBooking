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
    /// Interaction logic for AfishaPage.xaml
    /// </summary>
    public partial class AfishaPage : Page
    {
        public AfishaPage()
        {
            InitializeComponent();
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAfishaPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removeAfisha = GridAfisha.SelectedItems.Cast<Afisha>().ToList();
            if (removeAfisha.Count > 0)
            {
                if (MessageBox.Show($"Vi hotite udlalit sleduzushie  {removeAfisha.Count} elementi", "Udalenie",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    TheatreContext.Instance.Afisha.RemoveRange(removeAfisha);
                    TheatreContext.Instance.SaveChanges();
                    GridAfisha.ItemsSource = TheatreContext.Instance.Afisha.ToList();
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GridAfisha.ItemsSource = TheatreContext.Instance.Afisha.ToList();

            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Afisha afisha = (sender as Button).DataContext as Afisha;
            Manager.MainFrame.Navigate(new AddAfishaPage(afisha));
        }
    }
}
