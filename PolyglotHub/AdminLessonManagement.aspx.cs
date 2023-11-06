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
    public partial class WebForm6 : System.Web.UI.Page
    {
        
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_fp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateLevelList();
            }
            GridView1.DataBind();
        }

        void populateLevelList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT Name FROM LevelTable";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    LevelDropList.DataSource = dt;
                    // LevelDropList.DataTextField
                    LevelDropList.DataValueField = "Name";
                    LevelDropList.DataBind();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkIfLessonExist()
        {
            try
            {
                using(SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM LessonTable WHERE Chinese_Title = @ctxt";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@ctxt", ChineseTitleTB.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count >= 1)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
            } catch (Exception ex)
            {   
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
                return false;
            }
        }

        void addLesson()
        {
            try
            {
                if (LessonImage.HasFile)
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        string filepath = "~/Lesson_Img/UserProfileLessonHistoryIconnobg.png";
                        string filename = Path.GetFileName(LessonImage.PostedFile.FileName);
                        LessonImage.SaveAs(Server.MapPath("Lesson_Img/" + filename));
                        filepath = "~/Lesson_Img/" + filename;

                        string q2 = "SELECT * FROM LevelTable WHERE Name = @name";
                        SqlCommand cmd2 = new SqlCommand(q2, con);
                        cmd2.Parameters.AddWithValue("@name", LevelDropList.SelectedItem.Value);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da2.Fill(dt);
                        int getLevelId = Convert.ToInt32(dt.Rows[0]["Level_Id"]);

                        string q1 = "INSERT INTO LessonTable (English_Title,Chinese_Title,LessonImage,Level_Id) " +
                            "VALUES (@EngTitle, @ChTitle, @image, @Level_id)";
                        SqlCommand cmd1 = new SqlCommand(q1, con);

                        cmd1.Parameters.AddWithValue("@EngTitle", EnglishTitleTB.Text.Trim());
                        cmd1.Parameters.AddWithValue("@ChTitle", ChineseTitleTB.Text.Trim());
                        cmd1.Parameters.AddWithValue("@Level_id", getLevelId);
                        cmd1.Parameters.AddWithValue("@image", filepath);

                        if(EnglishTitleTB.Text.Trim().Equals("") || ChineseTitleTB.Text.Trim().Equals(""))
                        {
                            Response.Write("<script> alert('Please fill up all the input.'); </script>");
                        } else
                        {
                            int rowsAffected = cmd1.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Successful insertion
                                Response.Write("<script> alert('Lesson added successfully.'); </script>");
                                GridView1.DataBind();
                            }
                            else
                            {
                                // Failed to insert
                                Response.Write("<script> alert('Failed to add Lesson.'); </script>");
                            }
                            clearInput();
                        }                  
                    }
                } else
                {
                    Response.Write("<script> alert('Please select an image file to upload.'); </script>");
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void clearInput()
        {
            LessonIDTB.Text = "";
            ChineseTitleTB.Text = "";
            EnglishTitleTB.Text = "";
        }

        protected void LessonAddBtn_Click(object sender, EventArgs e)
        {
            if(checkIfLessonExist())
            {
                Response.Write("<script> alert(' Lesson Exist! '); </script>");
            } else
            {
                addLesson();
            }
        }

        protected void LessonIdSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "SELECT * FROM LessonTable WHERE Lesson_Id = @lesson_Id";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@EngTitle", EnglishTitleTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@ChTitle", ChineseTitleTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@lesson_Id", LessonIDTB.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count>=1)
                    {
                        EnglishTitleTB.Text = dt.Rows[0]["English_Title"].ToString();
                        ChineseTitleTB.Text = dt.Rows[0]["Chinese_Title"].ToString();
                        int levelId = Convert.ToInt32(dt.Rows[0]["Level_Id"].ToString().Trim());

                        string q2 = "SELECT Name FROM LevelTable WHERE Level_Id = @id";
                        SqlCommand cmd2 = new SqlCommand(q2, con);
                        cmd2.Parameters.AddWithValue("@id", levelId);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);

                        LevelDropList.SelectedValue = dt2.Rows[0]["Name"].ToString().Trim();
                        global_fp = dt.Rows[0]["LessonImage"].ToString();
                    } else
                    {
                        Response.Write("<script> alert(' INVALID ID '); </script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void LessonUpdateBtn_Click(object sender, EventArgs e)
        {
            if(checkIfLessonExist())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {

                        string filepath = "~/Lesson_Img/UserProfileLessonHistoryIconnobg.png";
                        string filename = Path.GetFileName(LessonImage.PostedFile.FileName);
                        if (filename == "" || filename == null)
                        {
                            filepath = global_fp;
                        } else
                        {
                            LessonImage.SaveAs(Server.MapPath("Lesson_Img/" + filename));
                            filepath = "~/Lesson_Img/" + filename;
                        }

                        con.Open();

                        string q2 = "SELECT * FROM LevelTable WHERE Name = @LevelName";
                        

                        SqlCommand cmd2 = new SqlCommand(q2, con);
                        cmd2.Parameters.AddWithValue("@LevelName", LevelDropList.SelectedItem.Value);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int lvlID = Convert.ToInt32(dt.Rows[0]["Level_Id"]);

                        string q1 = "UPDATE LessonTable SET English_Title=@ETitle, Chinese_Title=@CTitle, " +
                            "LessonImage=@ImgLink, Level_Id=@LevelId WHERE Lesson_Id = @LessonId";
                        SqlCommand cmd1 = new SqlCommand(q1, con);
                        cmd1.Parameters.AddWithValue("@ETitle", EnglishTitleTB.Text.Trim());
                        cmd1.Parameters.AddWithValue("@CTitle", ChineseTitleTB.Text.Trim());
                        cmd1.Parameters.AddWithValue("@LessonId", LessonIDTB.Text.Trim());
                        cmd1.Parameters.AddWithValue("@LevelId", lvlID);
                        cmd1.Parameters.AddWithValue("@ImgLink", filepath);

                        int rowsAffected = cmd1.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successful update
                            Response.Write("<script> alert('Lesson Updated successfully.'); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            // Failed to update
                            Response.Write("<script> alert('Failed to Update Lesson.'); </script>");
                        }
                        clearInput();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                }
            } else
            {
                Response.Write("<script>alert('Invalid ID');</script>");
            }
        }

        protected void LessonDeleteBtn_Click(object sender, EventArgs e)
        {
            if (checkIfLessonExist())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        string q1 = "DELETE FROM LessonTable WHERE Lesson_Id = @LessonId";
       
                        SqlCommand cmd1 = new SqlCommand(q1, con);
                        cmd1.Parameters.AddWithValue("@LessonId", LessonIDTB.Text.ToString());

                        int rowsAffected = cmd1.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successful delete
                            Response.Write("<script> alert('Lesson Deleted successfully.'); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            // Failed to delete
                            Response.Write("<script> alert('Failed to Delete Lesson.'); </script>");
                        }
                        clearInput();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid ID');</script>");
            }
        }
    }
}