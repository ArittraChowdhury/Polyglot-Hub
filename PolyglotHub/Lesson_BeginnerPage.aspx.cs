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
    public partial class WebForm17 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(strcon))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT * FROM LessonTable WHERE Level_Id = 1", connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string title = reader["Chinese_Title"].ToString();
                                    string text = reader["English_Title"].ToString();
                                    string filepath = reader["LessonImage"].ToString();
                                    Session["LessonID"] = reader["Lesson_Id"].ToString();

                                    // Create a new card and populate it with the retrieved data
                                    var card = new HtmlGenericControl("div");
                                    card.Attributes.Add("class", "card");
                                    card.Attributes.Add("style", "width:20em; margin:10px;");

                                    var imageElement = new HtmlImage();
                                    imageElement.Src = filepath; // Set the source path of your image
                                    imageElement.Attributes.Add("class", "card-image img-fluid"); // Add any additional attributes as needed
                                    imageElement.Style["height"] = "200px"; // Set the desired height
                                    card.Controls.Add(imageElement);

                                    var titleElement = new HtmlGenericControl("h2");
                                    titleElement.InnerText = title;
                                    card.Controls.Add(titleElement);

                                    var textElement = new HtmlGenericControl("p");
                                    textElement.InnerText = text;
                                    card.Controls.Add(textElement);

                                    var readMoreLink = new HtmlAnchor();
                                    readMoreLink.InnerText = "Read More..";
                                    readMoreLink.HRef = "LessonContent.aspx?LessonID=" + Session["LessonID"];
                                    readMoreLink.Attributes.Add("class", "btn btn-primary");
                                    card.Controls.Add(readMoreLink);

                                    var lineBreak = new HtmlGenericControl("br");
                                    card.Controls.Add(lineBreak);


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