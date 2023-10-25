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

namespace TheatreBooking
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private Client client = new Client();
        public RegistrationPage()
        {
            InitializeComponent();
            DataContext = client;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();  
            if (string.IsNullOrEmpty(client.Login))
                stringBuilder.AppendLine("Ukazhite login");
            if (string.IsNullOrEmpty(client.Password))
                stringBuilder.AppendLine("Ukazhite parol");
            if (string.IsNullOrEmpty(client.Name))
                stringBuilder.AppendLine("Ukazhite imya");
            if (string.IsNullOrEmpty(client.Surname))
                stringBuilder.AppendLine("Ukazhite familiu");
            if (string.IsNullOrEmpty(client.Email))
                stringBuilder.AppendLine("Ukazhite email");         
            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                
            }
            else
            {
                if (TheatreContext.Instance.Clients.Any(x => x.Login == client.Login))
                    MessageBox.Show("This login already exists!");
                else if(TheatreContext.Instance.Clients.Any(x => x.Email == client.Email))
                    MessageBox.Show("This email already exists!");
                else
                {
                    TheatreContext.Instance.Clients.Add(client);
                    TheatreContext.Instance.SaveChanges();
                    Manager.MainFrame.GoBack();
                }

            }
        }
    }
}
