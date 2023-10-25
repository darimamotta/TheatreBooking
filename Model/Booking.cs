using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreBooking.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual Afisha Afisha { get; set; }
        public int Place { get; set; }
        public int Line { get; set; }


    }
}
