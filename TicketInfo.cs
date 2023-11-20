using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreBooking
{
    public class TicketInfo
    {
        public TicketInfo(int line, int seat, bool isBooked)
        {
            Line = line;
            Seat = seat;
            IsBooked = isBooked;
        }

        public int Line { get; set; }
       public int Seat { get; set; }
       public bool IsBooked { get; set; }

       public bool IsChosenNow { get; set; }

    }
}
