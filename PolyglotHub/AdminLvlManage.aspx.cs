using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PolyglotHub
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LevelAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "INSERT INTO LevelTable (Name) VALUES (@Name)";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@Name", LevelNameTB.Text.Trim());
                    int rowsAffected = cmd1.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Successful insertion
                        Response.Write("<script> alert('Level added successfully.'); </script>");
                    }
                    else
                    {
                        // Failed to insert
                        Response.Write("<script> alert('Failed to add level.'); </script>");
                    }
                    inputClear();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('"+ex.Message +"'); </script>");
            }
        }

        protected void LeveUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "UPDATE LevelTable SET Name = @Name WHERE Level_Id = '"+ LevelID.Text.Trim()+ "'";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@Name", LevelNameTB.Text.Trim());
                    int rowsAffected = cmd1.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Successful insertion
                        Response.Write("<script> alert('Level Updated successfully.'); </script>");
                    }
                    else
                    {
                        // Failed to insert
                        Response.Write("<script> alert('Failed to Update level.'); </script>");
                    }
                    inputClear();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void LevelDeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "DELETE FROM LevelTable WHERE Level_Id = '"+ LevelID.Text.Trim() +"'";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    int rowsAffected = cmd1.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Successful insertion
                        Response.Write("<script> alert('Level Deleted successfully.'); </script>");
                    }
                    else
                    {
                        // Failed to insert
                        Response.Write("<script> alert('Failed to Delete level.'); </script>");
                    }
                    inputClear();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void inputClear()
        {
            LevelID.Text = "";
            LevelNameTB.Text = "";
        }

        protected void LevelIdSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM LevelTable WHERE Level_Id = '" + LevelID.Text.Trim() + "'";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // Populate Textbox
                            Session["currLvl_Id"] = dr.GetValue(0).ToString();
                            Session["nm"] = dr.GetValue(1).ToString();
                        }
                        LevelNameTB.Text = Session["nm"].ToString();
                    }
                    else
                    {
                        Response.Write("<script> alert('ID Not Found'); </script>");
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