using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Final_Plaetzler.Models
{
    public partial class Final_PlaetzlerContext : DbContext
    {
        public Final_PlaetzlerContext()
            : base("name=FinalDBEntities")
        {
           //Database.SetInitializer<Final_PlaetzlerContext>(new DropCreateDatabaseIfModelChanges<Final_PlaetzlerContext>());
        }

        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}