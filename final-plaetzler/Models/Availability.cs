using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Final_Plaetzler.Models
{
    public class Availability
    {
        public Availability()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int NumberAvailable { get; set; }
        public int NumberRemaining { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}