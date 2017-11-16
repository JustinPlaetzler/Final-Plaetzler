using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Plaetzler.Models;

namespace Final_Plaetzler
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                pnlLoginButton.Visible = true;
                pnlLogoutButton.Visible = false;
                pnlLogin.Visible = false;
                pnlValue.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                if (Session["LoggedInId"] != null)
                {
                    pnlLoginButton.Visible = false;
                    pnlLogin.Visible = false;
                    pnlLogoutButton.Visible = true;
                    pnlValue.Visible = true;
                    lblWelcome.Text = "Welcome, " + Session["FirstName"] + "!";
                    lblConfirmLogin.Text = "You have successfully logged in.";

                    using (Final_PlaetzlerContext context = new Final_PlaetzlerContext())
                    {
                        var customerId = Int32.Parse((String)Session["LoggedInId"]);
                        var orders = (from r in context.Orders
                                      where r.CustomerId == customerId
                                      select r).ToList();
                        if (orders.Count == 0)
                        {
                            pnlValue.Visible = false;
                            lblOrderInfo.Text = "You do not have any orders.";

                        }
                        else
                        {
                            lblOrderInfo.Text = "";
                            pnlValue.Visible = true;
                            foreach (var ord in orders)
                            {
                                TableRow row = new TableRow();
                                TableCell cell;

                                cell = new TableCell();
                                cell.Text = ord.Id.ToString();
                                row.Cells.Add(cell);

                                cell = new TableCell();
                                cell.Text = ord.StartDate.ToShortDateString();
                                row.Cells.Add(cell);

                                cell = new TableCell();
                                cell.Text = ord.Total.ToString("C");
                                row.Cells.Add(cell);

                                cell = new TableCell();
                                HyperLink link = new HyperLink();
                                link.Text = "Details";
                                //  link.Target = "_blank";
                                link.NavigateUrl = "orders.aspx?id=" + ord.Id;
                                cell.Controls.Add(link);
                                row.Cells.Add(cell);

                                tblOrdersList.Rows.Add(row);
                            }
                        }
                    }
                }
            }
        }


        protected void btnOpenLogin_Click(object sender, EventArgs e)
        {
            pnlLoginButton.Visible = false;
            pnlLogoutButton.Visible = false;
            pnlLogin.Visible = true;
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
                    pnlValue.Visible = true;
                    lblWelcome.Text = "Welcome, " + Session["FirstName"] + "!";
                    lblConfirmLogin.Text = "You have successfully logged in.";

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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            pnlLoginButton.Visible = true;
            pnlLogoutButton.Visible = false;
            pnlLogin.Visible = false;
            pnlValue.Visible = false;
            pnlBlank.Visible = false;
        }
    }
}