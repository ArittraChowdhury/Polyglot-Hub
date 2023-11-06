using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace PolyglotHub
{
    public partial class WebForm25 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                generateItem();
            }
        }

        private void generateItem()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("SELECT * FROM MemberTable", connection);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int datasize = dt.Rows.Count;

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Discussion", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["Title"].ToString();
                                string text = reader["Content"].ToString();
                                string date = reader["Date_Created"].ToString();
                                string discOwner = reader["Member_Id"].ToString();
                                
                                Session["DiscID"] = reader["Discussion_Id"].ToString();
                                int iD = Convert.ToInt32(reader["Discussion_Id"]);

                                Panel flexItem = new Panel();

                                var titleElement = new HtmlGenericControl("h2");
                                titleElement.InnerText = title;
                                flexItem.Controls.Add(titleElement);

                                var textElement = new HtmlGenericControl("h5");
                                textElement.InnerText = text;
                                flexItem.Controls.Add(textElement);

                                var TryThis = new HtmlAnchor();
                                TryThis.InnerText = "See";
                                TryThis.HRef = "PostContent.aspx?DiscId=" + iD;
                                TryThis.Attributes.Add("class", "btn btn-primary");
                                flexItem.Controls.Add(TryThis);

                                Literal literal1 = new Literal();
                                for (int x = 0; x < datasize; x++)
                                {
                                    if (discOwner.Equals(dt.Rows[x]["Member_Id"].ToString()))
                                    {
                                        literal1.Text = "<div> Posted by " + dt.Rows[x]["FirstName"] +" "+ dt.Rows[x]["LastName"] + " on " + date + "</div>";
                                        break;
                                    }
                                }
                                flexItem.Controls.Add(literal1);                       

                                HtmlGenericControl hr = new HtmlGenericControl("hr");
                                hr.Attributes["class"] = "custom-hr";
                                flexItem.Controls.Add(hr);



                                // Find the master page instance
                                var masterPage = Page.Master as Layout;

                                // Find the cardContainer within the content placeholder on the master page
                                var flexbox = masterPage.FindControl("ContentPlaceHolder1").FindControl("flexbox") as HtmlGenericControl;

                                if (flexbox != null)
                                {
                                    // Add the flex-item to the flexbox container
                                    flexbox.Controls.Add(flexItem);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

    }
}