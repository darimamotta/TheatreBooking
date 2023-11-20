using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreBooking.Model
{
    public class Afisha
    {
        public int Id { get; set; }
        public virtual Spectacle Spectacle { get; set; }
        public DateTime DateOfSpectacle { get; set; }
        public TimeSpan? Time {  get; set; }
        public virtual Saal Saal { get; set; }
        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
        
    }
}
