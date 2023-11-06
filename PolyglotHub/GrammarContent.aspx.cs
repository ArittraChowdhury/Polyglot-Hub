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
    public partial class WebForm14 : System.Web.UI.Page
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

                        int GID = 1;

                        if (Request.QueryString["GrammarID"] != null)
                        {
                            string grammarId = Request.QueryString["GrammarID"];
                            GID = Convert.ToInt32(grammarId);
                        }

                        string q1 = "SELECT * FROM GrammarTable Where Grammar_Id = @gId";
                        SqlCommand cmd1 = new SqlCommand(q1, connection);
                        cmd1.Parameters.AddWithValue("@gId", GID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            ChineseTitle.Text = dt.Rows[0]["Chinese_Title"].ToString();
                            EnglishTitle.Text = dt.Rows[0]["English_Title"].ToString();
                        }

                        using (SqlCommand command = new SqlCommand("SELECT * FROM GrammarContent WHERE Grammar_Id = '"+ GID +"'", connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string title = reader["SubHeading"].ToString();
                                    string text = reader["Content"].ToString();
                                    string example = reader["Example"].ToString();
                                    string[] exampleArray = example.Split(',');

                                    // Create a new card and populate it with the retrieved data
                                    var card = new HtmlGenericControl("div");
                                    card.Attributes.Add("class", "card");
                                    card.Attributes.Add("style", "margin:10px;");

                                    var titleElement = new HtmlGenericControl("h3");
                                    titleElement.InnerText = title;
                                    titleElement.Style["margin-left"] = "10px";
                                    card.Controls.Add(titleElement);

                                    var textElement = new HtmlGenericControl("p");
                                    textElement.InnerText = text;
                                    textElement.Style["margin-left"] = "10px";
                                    card.Controls.Add(textElement);

                                    for (int i = 0; i < exampleArray.Length; i++)
                                    {
                                        string format = $"{(i + 1)}. {exampleArray[i]}";
                                        HtmlGenericControl p = new HtmlGenericControl("p");
                                        p.InnerText = format;
                                        card.Controls.Add(p);
                                    }

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