using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Plaetzler.Models;

namespace Final_Plaetzler
{
    public partial class orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                Response.Redirect("Login.aspx?error=1");
            }

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    LoadOrder(Request.QueryString["id"].ToString());
                    pnlValue.Visible = true;
                }
                else
                {
                    pnlBlank.Visible = true;
                }
            }

            if (Session["LoggedInId"] != null)
            {
                Response.Redirect("account.aspx");
            }

        }

        protected void LoadOrder(String id)
        {

            using (Final_PlaetzlerContext context = new Final_PlaetzlerContext())
            {
                int ordId = Int32.Parse(id);
                var orders = (from r in context.Orders
                              where r.Id == ordId
                              select r).FirstOrDefault();
                if (orders != null)
                {
                    pnlValue.Visible = true;
                    lblOrderId.Text = orders.Id.ToString();
                    lblCustomer.Text = orders.Customer.FirstName + " " +
                        orders.Customer.LastName + "<br />" +
                        orders.Customer.Address + "<br />" +
                        orders.Customer.City + ", " + orders.Customer.State + " " + orders.Customer.Zip.ToString();
                    lblSDate.Text = orders.StartDate.ToShortDateString();
                    lblEDate.Text = orders.EndDate.ToShortDateString();
                    lblTotal.Text = orders.Total.ToString("C");
                }
        

/*               
                // Fill in order dates cells
                foreach (Order ord in orders)
                { 
                    double a = (ord.EndDate - ord.StartDate).TotalDays;
                    DateTime start = ord.StartDate;

                    TableCell cell = new TableCell();
                    
                    do
                    {
                        cell.Text = start.ToShortDateString();
                        tbrDate.Cells.Add(cell);

                        start.AddDays(1);
                        a--;
                    } while (a > 1);
                }

                // Fill in price cells
                foreach (Order ord in orders)
                {
                    double a = ord.OrderRange; 
                    int aid = ord.Availability.AvailabilityId;
                    double price = ord.Availability.Price;

                    TableRow row;
                    TableCell cell = new TableCell();

                    do
                    {
                        cell.Text = ord.Availability.Price.ToString("C");
                        tbrPrice.Cells.Add(cell);

                        date.AddDays(1);
                        a--;
                    } while (a > 1);
                }*/
            }
        }
        protected void btnCancelRes_Click(object sender, EventArgs e)
        {
            string custId = (string)(Session["LoggedInId"]);
            string ordId = (string)(Request.QueryString["id"]);
            int oid = Int32.Parse(ordId);
            int cid = Int32.Parse(custId);
            using (Final_PlaetzlerContext context = new Final_PlaetzlerContext())
            {
                var resToDelete = (from r in context.Orders
                                  where r.Id == oid
                                  select r).FirstOrDefault();
                context.Orders.Remove(resToDelete);
                context.SaveChanges();
            }
            
            Response.Redirect("account.aspx?id=" + cid);
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            string custId = (string)(Session["LoggedInId"]);
            int id = Int32.Parse(custId);
            Response.Redirect("account.aspx?id=" + id);
        }
    }
}