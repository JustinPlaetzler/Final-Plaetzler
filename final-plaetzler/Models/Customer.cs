using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Plaetzler.Models
{
    public class Customer
    {

        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(2)]
        public string State { get; set; }
        [Required]
        //[MaxLength(5)]
        public int Zip { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}