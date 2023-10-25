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
using TheatreBooking.Pages;

namespace TheatreBooking
{
    /// <summary>
    /// Interaction logic for GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Page
    {
        public GenrePage()
        {   
            InitializeComponent();
          
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Genre genre = (sender as Button).DataContext as Genre;
            Manager.MainFrame.Navigate(new PageAddGenre(genre));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAddGenre());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removeGenres = GridGenres.SelectedItems.Cast<Genre>().ToList();
            if(removeGenres.Count > 0)
            {
                if (MessageBox.Show($"Vi hotite udlalit sleduzushie  {removeGenres.Count} elementi", "Udalenie", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
                {
                    TheatreContext.Instance.Genres.RemoveRange(removeGenres);
                    TheatreContext.Instance.SaveChanges();
                    GridGenres.ItemsSource = TheatreContext.Instance.Genres.ToList();
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GridGenres.ItemsSource = TheatreContext.Instance.Genres.ToList();

            }
        }
    }
}
