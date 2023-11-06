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
    public partial class WebForm24 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "INSERT INTO Discussion (Title, Content, Date_Created, Status, Member_Id)" +
                        "VALUES (@title, @content, @date,@status, @mid)";
                    using(SqlCommand com = new SqlCommand(q1,con))
                    {
                        DateTime today = DateTime.Now.Date;
                        com.Parameters.AddWithValue("@title",PT_TB1.Text.Trim());
                        com.Parameters.AddWithValue("@content",PD_TB1.Text.Trim());
                        com.Parameters.AddWithValue("@date", today.ToString("yyyy-MM-dd"));
                        com.Parameters.AddWithValue("@status", "Active");
                        com.Parameters.AddWithValue("@mid", Session["MemberID"]);
                        int rowsAffected = com.ExecuteNonQuery();
                        if (rowsAffected>0)
                        {
                            Response.Write("<script> alert('Discussion has been made'); window.location='PostPage.aspx'; </script>");
                        } else
                        {
                            Response.Write("<script> alert(' Problem Occured! Contact Admin for Support '); </script>");
                        }
                    }
                }
            } catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }
    }
}