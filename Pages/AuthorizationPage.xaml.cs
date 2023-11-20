using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegistrationPage());

        }

        private void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            string login = txbox_login.Text;
            string password = txbox_password.Text;
            Client client = TheatreContext.Instance.Clients.FirstOrDefault(x=>x.Login == login&& x.Password == password);            
            if (client != null)
            {
                Manager.CurrentUser = client;
                Manager.MainFrame.Navigate(new AfishaPage());
            }
            else
            {
                Administrrator administrator = TheatreContext.Instance.Administrators.FirstOrDefault(x=>x.Login == login&&x.Password == password);
                if (administrator != null)
                {
                    Manager.MainFrame.Navigate(new AdminPage());

                }
                else
                    MessageBox.Show("Vvden nekorretny login");                
            }
            
        }
    }
}
