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
    public partial class WebForm7 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        private void addGrammar()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "INSERT INTO GrammarTable (Chinese_Title,English_Title,Level_Id) " +
                        "VALUES (@cnt, @ent, @levelID)";
                    SqlCommand cmd1 = new SqlCommand(q1, con);

                    cmd1.Parameters.AddWithValue("@cnt", CNTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@ent", ENTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@levelID", LevelList.SelectedValue.Trim());

                    if (CNTB.Text.Trim().Equals("") || ENTB.Text.Trim().Equals(""))
                    {
                        Response.Write("<script> alert('Please fill up the Input!'); </script>");
                    }
                    else
                    {
                        int rowsAffected = cmd1.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successful insertion
                            Response.Write("<script> alert('New Grammar added successfully.'); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            // Failed to insert
                            Response.Write("<script> alert('Failed to add Grammar.'); </script>");
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

        private void clearInput()
        {
            CNTB.Text = "";
            ENTB.Text = "";
        }

        private bool checkIfGrammarExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM GrammarTable WHERE Chinese_Title = @cnt";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@cnt", CNTB.Text.Trim());
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

        void updateGrammar()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE GrammarTable SET Chinese_Title = @cnt, English_Title=@ent, Level_Id=@levelID WHERE Grammar_Id = @gID", con))
                    {
                        cmd.Parameters.AddWithValue("@gID", GrammarIDTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@cnt", CNTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@ent", ENTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@levelID", LevelList.SelectedValue.Trim());

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

        private void deleteGrammar()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM GrammarTable WHERE Grammar_Id = @gID", con))
                    {
                        cmd.Parameters.AddWithValue("@gID", GrammarIDTB.Text.Trim());

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
                    string q1 = "SELECT * FROM GrammarTable WHERE Grammar_Id = @gID";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                    {
                        cmd.Parameters.AddWithValue("@gID", GrammarIDTB.Text.Trim());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                CNTB.Text = dt.Rows[0]["Chinese_Title"].ToString();
                                ENTB.Text = dt.Rows[0]["English_Title"].ToString();
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

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (checkIfGrammarExist()) {
                Response.Write("<script> alert(' Same Data Exist! '); </script>");
            }
            else
            {
                addGrammar();
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            updateGrammar();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            deleteGrammar();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            searchByID();
        }
    }
}