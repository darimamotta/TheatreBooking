﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreBooking.Model
{
    public class Spectacle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual List<Actor> Actors { get; set; } = new List<Actor>();
        
        public override string ToString() { return Title; }

    }
}
