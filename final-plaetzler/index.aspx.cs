using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Plaetzler.Models;

namespace Final_Plaetzler
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                pnlLoginButton.Visible = true;
                pnlLogoutButton.Visible = false;
                pnlLogin.Visible = false;
            }

            if (Session["LoggedInId"] != null)
            {
                pnlLoginButton.Visible = false;
                pnlLogin.Visible = false;
                pnlLogoutButton.Visible = true;
            }

            if (!Page.IsPostBack)
            {
                if (Session["LoggedInId"] != null)
                {
                    pnlLoginButton.Visible = false;
                    pnlLogin.Visible = false;
                    pnlLogoutButton.Visible = true;
                }
            }

        }

        protected void btnOpenLogin_Click(object sender, EventArgs e)
        {
            pnlLoginButton.Visible = false;
            pnlLogoutButton.Visible = false;
            pnlLogin.Visible = true;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            pnlLoginButton.Visible = true;
            pnlLogoutButton.Visible = false;
            pnlLogin.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (Final_PlaetzlerContext context = new Final_PlaetzlerContext())
            {
                var user = (from s in context.Customers
                            where s.Email == txtEmail.Text && s.Password == txtPassword.Text
                            select s).FirstOrDefault();


                if (user != null)
                {
                    Session["LoggedInId"] = user.Id.ToString();
                    Session["FirstName"] = user.FirstName;
                    Session["LastName"] = user.LastName;
                    lblLoginError.Text = "";
                    pnlLogin.Visible = false;
                    pnlLoginButton.Visible = false;
                    pnlLogoutButton.Visible = true;
                    lblWelcome.Text = "Welcome, " + Session["FirstName"] + "!";
                    lblConfirmLogin.Text = "You have successfully logged in.";
                    lblUnavailable.Text = "";

                }
                else
                {
                    pnlLogin.Visible = true;
                    pnlLoginButton.Visible = false;
                    pnlLogoutButton.Visible = false;
                    lblLoginError.Text = "User Name or Password are incorrect.";
                }
            }
        }

        // Only allow future dates to be selected from calendar.
        protected void cal_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (Session["LoggedInId"] != null)
            {
                // Find out if there are an adequate number of kayaks available for selected days.
                int numDays = Convert.ToInt32((calEndDate.SelectedDate - calStartDate.SelectedDate).TotalDays);
                int numKayaks = Int32.Parse(drpNumberKayaks.Text);

                using (Final_PlaetzlerContext context = new Final_PlaetzlerContext())
                {

                    var res = (from r in context.Availabilities
                               where r.Date == calStartDate.SelectedDate
                               select r).Take(numDays);
                    foreach (var avail in res)
                    {
                        if (avail.NumberRemaining >= numKayaks)
                        {
                            lblUnavailable.Text = "";
                            pnlReservation.Visible = false;
                            pnlConfirm.Visible = true;

                        }
                        else
                        {
                            pnlReservation.Visible = true;
                            pnlConfirm.Visible = false;
                            lblUnavailable.Text = "Rentals are unavailable for the dates you selected.";
                            break;
                        }
                        lblConfirm.Text = drpNumberKayaks.Text + " kayaks are available from " +
                            calStartDate.SelectedDate.ToShortDateString() + " to " +
                            calEndDate.SelectedDate.ToShortDateString() + ".";
                    }
                }
            }

            if (Session["LoggedInId"] == null)
            {
                pnlLoginButton.Visible = true;
                pnlLogoutButton.Visible = false;
                pnlLogin.Visible = false;
                lblUnavailable.Text = "Please login to continue.";
            }
            
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string custId = (string)(Session["LoggedInId"]);
                int id = Int32.Parse(custId);
                int numDays = Convert.ToInt32((calEndDate.SelectedDate - calStartDate.SelectedDate).TotalDays);
                int numKayaks = Int32.Parse(drpNumberKayaks.Text);

                using (Final_PlaetzlerContext entities = new Final_PlaetzlerContext())
                {
                    
                    try
                    {
                        var order = entities.Orders.Create();
                        order.StartDate = calStartDate.SelectedDate;
                        order.EndDate = calEndDate.SelectedDate;
                        order.NumberOrdered = Int32.Parse(drpNumberKayaks.SelectedValue);
                        order.CustomerId = id;

                        entities.Orders.Add(order);
                        entities.SaveChanges();
                        id = order.Id;
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Error Occured. Error Info: " + ex.Message;
                    }
                }
                using (Final_PlaetzlerContext entities = new Final_PlaetzlerContext())
                {
                    try
                    {
                        var res = (from r in entities.Availabilities
                                   where r.Date >= calStartDate.SelectedDate
                                   select r).Take(numDays);
                        foreach (var a in res)
                        {
                            a.NumberRemaining = a.NumberRemaining - numKayaks;
                            // Insert any additional changes to column values.
                        }

                        entities.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Error Occured. Error Info: " + ex.Message;
                    }
                }
                  Response.Redirect("orders.aspx?id=" + id);   
            }
        }
    }
}