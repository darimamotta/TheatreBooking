using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for AddSaalePage.xaml
    /// </summary>
    public partial class AddSaalePage : Page
    {
        private Saal saal = new Saal();
        public AddSaalePage(Saal saal=null)
        {
            InitializeComponent();
            
            if (saal != null)
            {
                this.saal = saal;
            }
            DataContext = this.saal;
        }

      

        private void Button_AddSaal_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(saal.Name))
                stringBuilder.AppendLine("Ukazhite imya zala");
            if ((saal.PlacesInLine)<0)
                stringBuilder.AppendLine("Ukazhite mesto v ryadu");
            if ((saal.Lines)<0)
                stringBuilder.AppendLine("Ukazhite ryad");
            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());

            }
            else
            {
                if (saal.Id == 0)
                {
                    TheatreContext.Instance.Saal.Add(saal);
                }

                TheatreContext.Instance.SaveChanges();
                Manager.MainFrame.GoBack();

            }
        }

        private void Button_CancelSaal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
