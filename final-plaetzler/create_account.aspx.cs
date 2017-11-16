using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Plaetzler.Models;

namespace Final_Plaetzler
{
    public partial class create_account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                pnlForm.Visible = false;
                pnlThankYou.Visible = true;
                using (Final_PlaetzlerContext entities = new Final_PlaetzlerContext())
                {
                    try
                    {   var customer = entities.Customers.Create();
                        customer.FirstName = txtFirstName.Text;
                        customer.LastName = txtLastName.Text;
                        customer.Address = txtAddress.Text;
                        customer.City = txtCity.Text;
                        customer.State = drpState.Text;
                        customer.Zip = int.Parse(txtZip.Text);
                        customer.Email = txtEmail.Text;
                        customer.Password = txtPassword.Text;


                        entities.Customers.Add(customer);
                        entities.SaveChanges();
                        Session["LoggedInId"] = customer.Id.ToString();
                        lblStatus.Text = "Account created. Thank you!";
                        
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Error Occured. Error Info: " + ex.Message;
                    }
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            string custId = (string)(Session["LoggedInId"]);
            int id = Int32.Parse(custId);
            Response.Redirect("account.aspx?id=" + id);
        }

        protected void btnRes_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}