﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreBooking.Model
{
    public class Saal
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int PlacesInLine { get; set; }
        public int Lines { get; set; }
        public override string ToString() { return Name; }
    }
}
