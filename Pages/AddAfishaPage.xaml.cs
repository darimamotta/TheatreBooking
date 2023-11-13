using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for AddAfishaPage.xaml
    /// </summary>
    public partial class AddAfishaPage : Page
    {
        private Afisha afisha = new Afisha();


        public AddAfishaPage(Afisha afisha = null)
        {
            InitializeComponent();
            if (afisha != null)
            {
                this.afisha = afisha;
            }
            DataContext = this.afisha;
            ComboBoxSpectactacle.ItemsSource = TheatreContext.Instance.Spectacles.ToList();
            ComboBoxSaal.ItemsSource = TheatreContext.Instance.Saal.ToList();
        }



        private void Button_CancelAfisha_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_AddAfisha_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (afisha.Spectacle == null)
                stringBuilder.AppendLine("Ukazhite nazvanie spectaclya");
            if (afisha.Saal == null)
                stringBuilder.AppendLine("Ukazhite  nazvanie saala");

            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());

            }
            else
            {
                if (afisha.Id == 0)
                {
                    TheatreContext.Instance.Afisha.Add(afisha);
                }

                TheatreContext.Instance.SaveChanges();
                Manager.MainFrame.GoBack();


            }
        }
    }
}
