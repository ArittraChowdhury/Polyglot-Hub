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
    public partial class WebForm12 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                try
                {
                    string level = Request.QueryString["level"];
                    int levelID = Convert.ToInt32(level);
                    using (SqlConnection connection = new SqlConnection(strcon))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("SELECT * FROM GrammarTable WHERE Level_Id = '"+ levelID + "'", connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string title = reader["Chinese_Title"].ToString();
                                    string text = reader["English_Title"].ToString();
                                    Session["GrammarID"] = reader["Grammar_Id"].ToString();

                                    // Create a new card and populate it with the retrieved data
                                    var card = new HtmlGenericControl("div");
                                    card.Attributes.Add("class", "card");
                                    card.Attributes.Add("style", "width:20em; margin:10px;");

                                    var titleElement = new HtmlGenericControl("h2");
                                    titleElement.InnerText = title;
                                    card.Controls.Add(titleElement);

                                    var textElement = new HtmlGenericControl("p");
                                    textElement.InnerText = text;
                                    card.Controls.Add(textElement);

                                    var readMoreLink = new HtmlAnchor();
                                    readMoreLink.InnerText = "Read More..";
                                    readMoreLink.HRef = "GrammarContent.aspx?GrammarId=" + Session["GrammarID"]; // Include GrammarId in the URL
                                    readMoreLink.Attributes.Add("class", "btn btn-primary");
                                    card.Controls.Add(readMoreLink);

                                    // Find the master page instance
                                    var masterPage = Page.Master as Layout;

                                    // Find the cardContainer within the content placeholder on the master page
                                    var cardContainer = masterPage.FindControl("ContentPlaceHolder1").FindControl("cardContainer") as HtmlGenericControl;

                                    // Add the card to the container
                                    cardContainer.Controls.Add(card);
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
}