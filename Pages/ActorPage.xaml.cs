﻿using System;
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
    /// Interaction logic for ActorPage.xaml
    /// </summary>
    public partial class ActorPage : Page
    {
        public ActorPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddActorPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removeActor = GridActor.SelectedItems.Cast<Actor>().ToList();
            if (removeActor.Count > 0)
            {
                if (MessageBox.Show($"Vi hotite udlalit sleduzushie  {removeActor.Count} elementi", "Udalenie",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    TheatreContext.Instance.Actors.RemoveRange(removeActor);
                    TheatreContext.Instance.SaveChanges();
                    GridActor.ItemsSource = TheatreContext.Instance.Genres.ToList();
                }
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Actor actor = (sender as Button).DataContext as Actor;
            Manager.MainFrame.Navigate(new AddActorPage(actor));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                GridActor.ItemsSource = TheatreContext.Instance.Actors.ToList();

            }
        }
    }
}
