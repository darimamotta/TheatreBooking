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
    /// Interaction logic for PageAddGenre.xaml
    /// </summary>
    public partial class PageAddGenre : Page
    {
        private Genre genre = new Genre();
        public PageAddGenre(Genre genre=null)
        {
            InitializeComponent();
            if (genre != null )
            {
                this.genre = genre;
            }
            DataContext = this.genre;
        }
         
        private void Button_AddGenre_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(genre.Title))
                stringBuilder.AppendLine("Ukazhite nazvanie genra");
            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());

            }
            else
            {
                if (genre.Id == 0)
                {   
                    TheatreContext.Instance.Genres.Add(genre);
                }
                      
                    TheatreContext.Instance.SaveChanges();
                    Manager.MainFrame.GoBack();            

            }

        }

        private void Button_CancelGenre_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
