using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TheatreBooking.Model;

namespace TheatreBooking
{
    internal class Manager
    {
        public static Frame MainFrame { get; set; }
        public static Client CurrentUser { get; set; }
    }
}
