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
    public partial class WebForm11 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        private void clearInput()
        {
            qIDTB.Text = "";
            qTxtTB.Text = "";
            c1TB.Text = "";
            c2TB.Text = "";
            c3TB.Text = "";
            ansTB.Text = "";
        }

        private void addQuestion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "INSERT INTO QuestionTable (Content,FirstChoice,SecondChoice,ThirdChoice,Answer,ReadingTest_Id) " +
                        "VALUES (@c,@fc,@sc,@tc,@ans,@rtID)";
                    SqlCommand cmd1 = new SqlCommand(q1, con);

                    cmd1.Parameters.AddWithValue("@c", qTxtTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@fc", c1TB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@sc", c2TB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@tc", c3TB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@ans", ansTB.Text.Trim());
                    cmd1.Parameters.AddWithValue("@rtID", TestIDList.SelectedValue.Trim());

                    if (qTxtTB.Text.Trim().Equals("") || c1TB.Text.Trim().Equals("") || c2TB.Text.Trim().Equals("") || c3TB.Text.Trim().Equals("") || ansTB.Text.Trim().Equals(""))
                    {
                        Response.Write("<script> alert('All forms need to filled!'); </script>");
                    }
                    else
                    {
                        int rowsAffected = cmd1.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successful insertion
                            Response.Write("<script> alert('New Question added successfully.'); </script>");
                            GridView1.DataBind();
                        }
                        else
                        {
                            // Failed to insert
                            Response.Write("<script> alert('Failed to add Question.'); </script>");
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

        private bool checkIfQuestionExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM QuestionTable WHERE Content = @c";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@c", qTxtTB.Text.Trim());
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

        void updateQuestion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE QuestionTable SET Content = @c, FirstChoice = @fc, SecondChoice = @sc, ThirdChoice = @tc, Answer = @ans, ReadingTest_Id = @rtID WHERE Question_Id = @qID", con))
                    {
                        cmd.Parameters.AddWithValue("@qID", qIDTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@c", qTxtTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@fc", c1TB.Text.Trim());
                        cmd.Parameters.AddWithValue("@sc", c2TB.Text.Trim());
                        cmd.Parameters.AddWithValue("@tc", c3TB.Text.Trim());
                        cmd.Parameters.AddWithValue("@ans", ansTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@rtID", TestIDList.SelectedValue.Trim());

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

        private void deleteQuestion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM QuestionTable WHERE Question_Id = @qID", con))
                    {
                        cmd.Parameters.AddWithValue("@qID", qIDTB.Text.Trim());

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
                    string q1 = "SELECT * FROM QuestionTable WHERE Question_Id = @qID";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                    {
                        cmd.Parameters.AddWithValue("@qID", qIDTB.Text.Trim());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                qTxtTB.Text = dt.Rows[0]["Content"].ToString();
                                c1TB.Text = dt.Rows[0]["FirstChoice"].ToString();
                                c2TB.Text = dt.Rows[0]["SecondChoice"].ToString();
                                c3TB.Text = dt.Rows[0]["ThirdChoice"].ToString();
                                ansTB.Text = dt.Rows[0]["Answer"].ToString();
                                TestIDList.SelectedValue = dt.Rows[0]["ReadingTest_Id"].ToString();
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

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            searchByID();
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (checkIfQuestionExist())
            {
                Response.Write("<script> alert(' Data Exist! '); </script>");
            } else
            {
                addQuestion();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            updateQuestion();
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            deleteQuestion();
        }
    }


}