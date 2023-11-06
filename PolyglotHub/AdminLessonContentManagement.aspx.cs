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
    public partial class WebForm29 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        bool checkIfContentExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM LessonContent WHERE Content = @ctxt";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@ctxt", ChineseTextTB.Text.Trim());
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

        void clearInput()
        {
            ChineseTextTB.Text = "";
            TextBox1.Text = "";
            TranslationTB.Text = "";
        }

        void addLesson()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "INSERT INTO LessonContent (Content,Pinyin,Translation,Lesson_Id) " +
                        "VALUES (@content, @pinyin, @translate, @lessonID)";
                    SqlCommand cmd1 = new SqlCommand(q1, con);

                    cmd1.Parameters.AddWithValue("@content", ChineseTextTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@pinyin", TextBox1.Text.Trim());
                    cmd1.Parameters.AddWithValue("@translate", TranslationTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@lessonID", LessonIDList.SelectedValue.Trim());
                    
                    if (ChineseTextTB.Text.Trim().Equals("") || TextBox1.Text.Trim().Equals("") || TranslationTB.Text.Trim().Equals(""))
                    {
                        Response.Write("<script> alert('Please fill up the Input!'); </script>");
                    } else
                    {
                        int rowsAffected = cmd1.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successful insertion
                            Response.Write("<script> alert('Content added successfully.'); </script>");
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

        protected void ContentAddBtn_Click(object sender, EventArgs e)
        {
            if (checkIfContentExist())
            {
                Response.Write("<script> alert(' Content already Existed in the system! '); </script>");
            }
            else
            {
                addLesson();
            }  
        }

        void updateContent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE LessonContent SET Content = @content, Pinyin=@pinyin, Translation=@translation, Lesson_Id=@lessonID WHERE LessonContent_Id = @contentID",con))
                    {
                        cmd.Parameters.AddWithValue("@contentID",LessonContentIDTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@content",ChineseTextTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@pinyin", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@translation", TranslationTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@lessonID", LessonIDList.SelectedValue.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script> alert(' UPDATE Success '); </script>");
                            GridView1.DataBind();
                        } else
                        {
                            Response.Write("<script> alert(' UPDATE Fail '); </script>");
                        }
                        clearInput();
                    }
                }
            }catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }
        protected void ContentUpdateBtn_Click(object sender, EventArgs e)
        {
            updateContent();
        }

        void deleteContent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM LessonContent WHERE LessonContent_Id = @contentID", con))
                    {
                        cmd.Parameters.AddWithValue("@contentID", LessonContentIDTB.Text.Trim());

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
        protected void ContentDeleteBtn_Click(object sender, EventArgs e)
        {
            deleteContent();
        }

        protected void ContentIDSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection (strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM LessonContent WHERE LessonContent_Id = @contentID";
                    using(SqlCommand cmd = new SqlCommand(q1,con))
                    {
                        cmd.Parameters.AddWithValue("@contentID",LessonContentIDTB.Text.Trim());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if(dt.Rows.Count>0)
                            {
                                ChineseTextTB.Text = dt.Rows[0]["Content"].ToString();
                                TextBox1.Text = dt.Rows[0]["Pinyin"].ToString();
                                TranslationTB.Text = dt.Rows[0]["Translation"].ToString();
                                LessonIDList.SelectedValue = dt.Rows[0]["Lesson_Id"].ToString();
                            } else
                            {
                                Response.Write("<script> alert(' DATA NOT FOUND '); </script>");
                            }
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