using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Final_Plaetzler.Models;

namespace Final_Plaetzler
{
    public partial class loader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (uploadFile.HasFile)
            {
                using (Final_PlaetzlerContext entities = new Final_PlaetzlerContext())
                {
                    var newAvailability = entities.Availabilities.Create();
                    MemoryStream stream = null;

                    try
                    {
                        //copy the data into memory
                        stream = new MemoryStream(uploadFile.FileBytes);
                        //give the data we have in meory to the XMLTextReader
                        XmlTextReader r = new XmlTextReader(stream);

                        string lastElementName = "";
                        while (r.Read())
                        {
                            switch (r.NodeType)
                            {
                                case XmlNodeType.Element:
                                    if (r.Name == "ROW")
                                    {
                                    }
                                    else if (r.Name == "FIELD1" || r.Name == "FIELD2" ||
                                             r.Name == "FIELD3" || r.Name == "FIELD4")
                                    {
                                        lastElementName = r.Name;
                                    }
                                    break;

                                case XmlNodeType.Text:
                                    switch (lastElementName)
                                    {
                                        case ("FIELD1"): newAvailability.Date = DateTime.Parse(r.Value); break;
                                        case ("FIELD2"): newAvailability.Price = Double.Parse(r.Value); break;
                                        case ("FIELD3"): newAvailability.NumberAvailable = Int32.Parse(r.Value); break;
                                        case ("FIELD4"): newAvailability.NumberRemaining = Int32.Parse(r.Value); break;

                                    }
                                    break;

                                case XmlNodeType.EndElement:
                                    if (r.Name == "ROW")
                                    {
                                        entities.Availabilities.Add(newAvailability);
                                        entities.SaveChanges();

                                    }
                                    break;
                            }
                        }

                        //Set upload panel invisible
                        pnlUpload.Visible = false;
                        //Set display panel to visible
                        pnlDisplay.Visible = true;

                    }
                    catch (Exception)
                    { }
                    finally
                    { stream.Close(); }
                }

            }
        }
    }
}