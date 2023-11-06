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
    public partial class WebForm9 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        private void clearInput()
        {
            VCID.Text = "";
            CNTB.Text = "";
            PNTB.Text = "";
            ENTB.Text = "";
        }

        private void addVocab()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "INSERT INTO VocabularyWord (ChineseWord,Pinyin,EnglishText,Level_Id) " +
                        "VALUES (@cw, @pn,@et, @lID)";
                    SqlCommand cmd1 = new SqlCommand(q1, con);

                    cmd1.Parameters.AddWithValue("@cw", CNTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@pn", PNTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@et", ENTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@lID", LevelList.SelectedValue.Trim());

                    if (CNTB.Text.Trim().Equals("") || PNTB.Text.Trim().Equals("") || ENTB.Text.Trim().Equals(""))
                    {
                        Response.Write("<script> alert('Please fill up the Input!'); </script>");
                    }
                    else
                    {
                        int rowsAffected = cmd1.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successful insertion
                            Response.Write("<script> alert('New Word added successfully.'); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            // Failed to insert
                            Response.Write("<script> alert('Failed to add Word.'); </script>");
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

        private bool checkIfwordExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM VocabularyWord WHERE ChineseWord = @cn";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@cn", CNTB.Text.Trim());
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

        void updateWord()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE VocabularyWord SET ChineseWord = @cw, Pinyin=@pn, EnglishText=@en, Level_Id = @lID WHERE VocabularyWord_Id = @vwID", con))
                    {
                        cmd.Parameters.AddWithValue("@vwID", VCID.Text.Trim());
                        cmd.Parameters.AddWithValue("@cw", CNTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@en", ENTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@pn", PNTB.Text.Trim());
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

        private void deleteWord()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM VocabularyWord WHERE VocabularyWord_Id = @vwID", con))
                    {
                        cmd.Parameters.AddWithValue("@vwID", VCID.Text.Trim());

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
                    string q1 = "SELECT * FROM VocabularyWord WHERE VocabularyWord_Id = @vwID";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                    {
                        cmd.Parameters.AddWithValue("@vwID", VCID.Text.Trim());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                CNTB.Text = dt.Rows[0]["ChineseWord"].ToString();
                                PNTB.Text = dt.Rows[0]["Pinyin"].ToString();
                                ENTB.Text = dt.Rows[0]["EnglishText"].ToString();
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

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if(checkIfwordExist())
            {
                Response.Write("<script> alert(' Word Exist! '); </script>");
            } else
            {
                addVocab();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            updateWord();
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            deleteWord();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            searchByID();
        }
    }
}