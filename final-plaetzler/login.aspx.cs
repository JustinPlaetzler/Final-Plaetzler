using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Plaetzler.Models;

namespace Final_Plaetzler
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load()
        {
             if (Session["LoggedInId"] == null)
            {
                pnlLogin.Visible = true;
                pnlDetails.Visible = false;
            }
            else
            {
                pnlLogin.Visible = false;
                pnlDetails.Visible = true;
                lblUserFullName.Text = Session["LastName"] + ", " + Session["FirstName"];
            }

            if (Request.QueryString["error"] != null)
            {
                lblResults.Text = "You are not authorized to view pages until you login.";
            }
        }

        protected void LogOut(object sender, EventArgs e)
        {
            /*Session["LoggedInId"]=null;
            Session["FirstName"]=null;
            Session["LastName"]=null;
            */
            Session.Clear();
            Response.Redirect("login.aspx");
        }


        protected void Login(object sender, EventArgs e)
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
                    lblResults.Text = "";
                    lblUserFullName.Text = Session["LastName"] + ", " + Session["FirstName"];
                    Response.Redirect("account.aspx");
                    pnlLogin.Visible = false;
                    pnlDetails.Visible = false;

                }
                else
                {
                    lblResults.Text = "Email Address or Password are incorrect.";
                }
            }
        }
    }
}