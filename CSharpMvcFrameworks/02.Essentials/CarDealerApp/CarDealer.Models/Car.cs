﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            this.Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
