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
    /// Interaction logic for AddSpectaclePage.xaml
    /// </summary>
    public partial class AddSpectaclePage : Page
    {
        private Spectacle spectacle = new Spectacle();
        
        public AddSpectaclePage(Spectacle spectacle=null)
        {
            InitializeComponent();
            if (spectacle != null)
            {
                this.spectacle = spectacle;
            }
            DataContext = this.spectacle;
            ComboBoxGenre.ItemsSource= TheatreContext.Instance.Genres.ToList();
            ComboBoxAddActor.ItemsSource=TheatreContext.Instance.Actors.ToList();
            LstBoxOfAddedActor.ItemsSource =this.spectacle.Actors;


        }

     
        private void Button_AddSpectacle_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(spectacle.Title))
                stringBuilder.AppendLine("Ukazhite nazvaine spectaclya");
            if ((spectacle.Price) < 0)
                stringBuilder.AppendLine("Ukazhite stoimost");
            if (spectacle.Genre==null)
                stringBuilder.AppendLine("Ukazhite genre");
            if ((spectacle.Actors.Count) == 0)
                stringBuilder.AppendLine("Ukazhite actera");
            
            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());

            }
            else
            {
                if (spectacle.Id == 0)
                {
                    TheatreContext.Instance.Spectacles.Add(spectacle);
                }

                TheatreContext.Instance.SaveChanges();
                Manager.MainFrame.GoBack();

            }
        }

        private void Button_CancelSpectacle_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnAddActorSpc(object sender, RoutedEventArgs e)
        {
            Actor actor = ComboBoxAddActor.SelectedItem as Actor;
            spectacle.Actors.Add(actor);
            LstBoxOfAddedActor.ItemsSource = null;
            LstBoxOfAddedActor.ItemsSource = spectacle.Actors;

        }
    }
}
