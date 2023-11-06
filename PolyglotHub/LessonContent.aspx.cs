using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PolyglotHub
{
    public partial class WebForm18 : System.Web.UI.Page
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

                        int LID = 1;

                        if (Request.QueryString["LessonID"] != null)
                        {
                            string lessonId = Request.QueryString["LessonID"];
                            LID = Convert.ToInt32(lessonId);
                        }
                        string q1 = "SELECT * FROM LessonTable Where Lesson_Id = @LessonId";
                        SqlCommand cmd1 = new SqlCommand(q1, connection);
                        cmd1.Parameters.AddWithValue("@LessonId", LID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if(dt.Rows.Count > 0)
                        {
                            ChineseTitle.Text = dt.Rows[0]["Chinese_Title"].ToString();
                            EnglishTitle.Text = dt.Rows[0]["English_Title"].ToString();
                        }

                        using (SqlCommand command = new SqlCommand("SELECT * FROM LessonContent WHERE Lesson_Id = '" + LID + "'", connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string pinyin = reader["Pinyin"].ToString();
                                    string chineseText = reader["Content"].ToString();
                                    string englishTranslate = reader["Translation"].ToString();

                                    // Create a new card and populate it with the retrieved data
                                    var card = new HtmlGenericControl("div");
                                    card.Attributes.Add("class", "card");
                                    card.Attributes.Add("style", "margin:10px;");

                                    var titleElement = new HtmlGenericControl("p");
                                    titleElement.InnerText = pinyin;
                                    titleElement.Style["margin-left"] = "10px";
                                    card.Controls.Add(titleElement);

                                    var textElement = new HtmlGenericControl("h4");
                                    textElement.InnerText = chineseText;
                                    textElement.Style["margin-left"] = "10px";
                                    card.Controls.Add(textElement);

                                    var textElement2 = new HtmlGenericControl("p");
                                    textElement2.InnerText = englishTranslate;
                                    textElement2.Style["margin-left"] = "10px";
                                    card.Controls.Add(textElement2);                                  

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