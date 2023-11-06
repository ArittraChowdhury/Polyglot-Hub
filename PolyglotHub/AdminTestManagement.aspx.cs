using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PolyglotHub
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        private void clearInput()
        {
            TSID.Text = "";
            TTLTB.Text = "";
        }

        private void addText()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "INSERT INTO ReadingTest (TestText,Level_Id) " +
                        "VALUES (@tt, @lID)";
                    SqlCommand cmd1 = new SqlCommand(q1, con);

                    cmd1.Parameters.AddWithValue("@tt", TTLTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@lID", LevelList.SelectedValue.Trim());

                    if (TTLTB.Text.Trim().Equals(""))
                    {
                        Response.Write("<script> alert('Please fill up the Input!'); </script>");
                    }
                    else
                    {
                        int rowsAffected = cmd1.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successful insertion
                            Response.Write("<script> alert('New ReadingTest added successfully.'); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            // Failed to insert
                            Response.Write("<script> alert('Failed to add ReadingTest.'); </script>");
                        }
                        clearInput();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        private bool checkIfTextExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM ReadingTest WHERE TestText = @tt";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@tt", TTLTB.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
                return false;
            }
        }

        void updateText()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE ReadingTest SET TestText = @tt, Level_Id = @lID WHERE ReadingTest_Id = @rdtID", con))
                    {
                        cmd.Parameters.AddWithValue("@rdtID", TSID.Text.Trim());
                        cmd.Parameters.AddWithValue("@tt", TTLTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@lID", LevelList.SelectedValue.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script> alert(' UPDATE Success '); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            Response.Write("<script> alert(' UPDATE Fail '); </script>");
                        }
                        clearInput();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        private void deleteText()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ReadingTest WHERE ReadingTest_Id = @rdtID", con))
                    {
                        cmd.Parameters.AddWithValue("@rdtID", TSID.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script> alert(' DELETE Success '); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            Response.Write("<script> alert(' DELETE Fail '); </script>");
                        }
                        clearInput();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }


        private void searchByID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM ReadingTest WHERE ReadingTest_Id = @rdtID";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                    {
                        cmd.Parameters.AddWithValue("@rdtID", TSID.Text.Trim());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                TTLTB.Text = dt.Rows[0]["TestText"].ToString();
                                LevelList.SelectedValue = dt.Rows[0]["Level_Id"].ToString();
                            }
                            else
                            {
                                Response.Write("<script> alert(' DATA NOT FOUND '); </script>");
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

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            searchByID();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (checkIfTextExist())
            {
                Response.Write("<script> alert(' Data Exist! '); </script>");
            } else
            {
                addText();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            updateText();
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            deleteText();
        }
    }
}