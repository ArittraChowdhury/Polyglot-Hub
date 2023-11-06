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
    public partial class WebForm19 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateFlexItems();
            }
        }


        private void GenerateFlexItems()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    int i = 1;
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM LevelTable", connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int datasize = dt.Rows.Count;
                    

                    using (SqlCommand command = new SqlCommand("SELECT * FROM ReadingTest", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["TestText"].ToString();
                                string text = reader["Level_Id"].ToString();
                                Session["ReadingTestID"] = reader["ReadingTest_Id"].ToString();
                                //Response.Write("<script> alert('"+ Session["TestID"].ToString() +"'); </script>");
                                int testID = Convert.ToInt32(reader["ReadingTest_Id"]);

                                Panel flexItem = new Panel();
                                flexItem.CssClass = "flex-item";

                                var titleElement = new HtmlGenericControl("h4");
                                titleElement.InnerText = title;
                                flexItem.Controls.Add(titleElement);

                                Literal literal = new Literal();
                                literal.Text = "<div>Sample Test " + i + "</div>";
                                flexItem.Controls.Add(literal);
                                i++;

                                Literal literal2 = new Literal();

                                for(int x = 0; x<datasize; x++)
                                {
                                    if(text.Equals(dt.Rows[x]["Level_Id"].ToString()))
                                    {
                                        literal2.Text= "<div> Difficulty : "+ dt.Rows[x]["Name"] +"</div>";
                                        break;
                                    }
                                }
                       
                                flexItem.Controls.Add(literal2);

                                int currentTestID = testID;
                                var TryThis = new HtmlAnchor();
                                TryThis.InnerText = "Attempt";
                                TryThis.HRef = "TestQuestionPage.aspx?ReadingTestId=" + currentTestID;
                                TryThis.Attributes.Add("class", "btn btn-primary");
                                flexItem.Controls.Add(TryThis);

                                HtmlGenericControl hr = new HtmlGenericControl("hr");
                                hr.Attributes["class"] = "custom-hr";
                                flexItem.Controls.Add(hr);

                                HtmlGenericControl newLine = new HtmlGenericControl("br");
                                flexItem.Controls.Add(newLine);

                                // Find the master page instance
                                var masterPage = Page.Master as Layout;

                                // Find the cardContainer within the content placeholder on the master page
                                var flexbox = masterPage.FindControl("ContentPlaceHolder1").FindControl("flexbox") as HtmlGenericControl;

                                if(flexbox!=null)
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