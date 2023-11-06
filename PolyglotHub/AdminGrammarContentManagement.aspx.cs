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
    public partial class WebForm30 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        private void clearInput()
        {
            GCIDTB.Text = "";
            SHTB.Text = "";
            CTTB.Text = "";
            EXTB.Text = "";
        }

        private void addContent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "INSERT INTO GrammarContent (SubHeading,Content,Example,Grammar_Id) " +
                        "VALUES (@sh, @ctn,@ex, @grammarID)";
                    SqlCommand cmd1 = new SqlCommand(q1, con);

                    cmd1.Parameters.AddWithValue("@sh", SHTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@ctn", CTTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@ex", EXTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@grammarID", GrammarList.SelectedValue.Trim());

                    if (SHTB.Text.Trim().Equals("") || CTTB.Text.Trim().Equals("") || EXTB.Text.Trim().Equals(""))
                    {
                        Response.Write("<script> alert('Please fill up the Input!'); </script>");
                    }
                    else
                    {
                        int rowsAffected = cmd1.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successful insertion
                            Response.Write("<script> alert('New Content added successfully.'); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            // Failed to insert
                            Response.Write("<script> alert('Failed to add Content.'); </script>");
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

        private bool checkIfContentrExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM GrammarContent WHERE SubHeading = @sh";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@sh", SHTB.Text.Trim());
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

        void updateContent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE GrammarContent SET SubHeading = @sh, Content=@content, Example=@ex, Grammar_Id = @gID WHERE GrammarContent_Id = @gcID", con))
                    {
                        cmd.Parameters.AddWithValue("@gcID", GCIDTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@sh", SHTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@content", CTTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@ex", EXTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@gID", GrammarList.SelectedValue.Trim());

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

        private void deleteContent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM GrammarContent WHERE GrammarContent_Id = @gcID", con))
                    {
                        cmd.Parameters.AddWithValue("@gcID", GCIDTB.Text.Trim());

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
                    string q1 = "SELECT * FROM GrammarContent WHERE GrammarContent_Id = @gcID";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                    {
                        cmd.Parameters.AddWithValue("@gcID", GCIDTB.Text.Trim());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                SHTB.Text = dt.Rows[0]["SubHeading"].ToString();
                                CTTB.Text = dt.Rows[0]["Content"].ToString();
                                EXTB.Text = dt.Rows[0]["Example"].ToString();
                                GrammarList.SelectedValue = dt.Rows[0]["Grammar_Id"].ToString();
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

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if(checkIfContentrExist())
            {
                Response.Write("<script> alert(' Content Exist in the system! '); </script>");
            } else
            {
                addContent();
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            updateContent();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            deleteContent();
        }
    }
}