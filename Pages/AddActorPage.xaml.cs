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
    /// Interaction logic for AddActorPage.xaml
    /// </summary>
    public partial class AddActorPage : Page
    {
        private Actor actor = new Actor();
        public AddActorPage(Actor actor=null)
        {
            InitializeComponent();
            if (actor != null )
            {
                this.actor = actor;
            }
            DataContext = this.actor;
        }

        private void Button_AddGenre_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(actor.Name))
                stringBuilder.AppendLine("Ukazhite imya actera");
            if(string.IsNullOrEmpty(actor.Surname))
                stringBuilder.AppendLine("Ukazhite familiu actera");
            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());

            }
            else
            {
                if (actor.Id == 0)
                {
                    TheatreContext.Instance.Actors.Add(actor);
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
