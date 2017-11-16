using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Final_Plaetzler.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartDate{ get; set;}
        public DateTime EndDate { get; set; }
        public int NumberOrdered { get; set; }
        public int CustomerId { get; set; }
        
        public virtual Customer Customer { get; set; }
        public virtual Availability Availability { get; set; }

        public double OrderRange
        {
            get
            {
                double a = (EndDate - StartDate).TotalDays;
                return a;
            }
        }

/*        public string OrderPrices
        {
            get 
            {
                double a = OrderRange;
                DateTime start = StartDate;
                var orderPrices = new List<string>();

                do
                {
                    if (a == OrderRange && start == Availability.Date)
                    {
                        orderPrices.Add(Availability.Price.ToString());
                    }
                    else if (start == Availability.Date)
                    {
                        orderPrices.Add("," + Availability.Price.ToString());
                    }
                    start.AddDays(1);
                    a--;
                } while (a > -1);

                return orderPrices.ToString();
            }
        }

        public string OrderDates
        {
            get
            {
                double a = OrderRange;
                DateTime start = StartDate;
                var orderDates = new List<string>();

                do
                {
                    if (a == OrderRange)
                    {
                        orderDates.Add(start.ToShortDateString());
                    }
                    else
                    {
                        orderDates.Add("," + start.ToShortDateString());
                    }
                    start.AddDays(1);
                    a--;
                } while (a > -1);

                return orderDates.ToString();
            }
        }*/

        public double Total
        {
            get
            {
                double a = OrderRange;
                DateTime start = StartDate;
                double total = 0;
                
                    using (Final_PlaetzlerContext entities = new Final_PlaetzlerContext())
                    {
                      
                        var res = (from r in entities.Availabilities
                                    where r.Date >= start
                                    select r.Price).Take(Convert.ToInt32(a));
                        foreach (var p in res)
                        {
                            total = total + p;
                        } 
                    }
                    
                return total;
            }
        }
    }
}