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
    public partial class WebForm31 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        void searchbyID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "SELECT * FROM Discussion WHERE Discussion_Id = @d_Id";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@d_Id", discIDTB.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        title_TB.Text = dt.Rows[0]["Title"].ToString();
                        content_TB.Text = dt.Rows[0]["Content"].ToString();
                        DC_TB.Text = dt.Rows[0]["Date_Created"].ToString();
                        DS_TB.Text = dt.Rows[0]["Status"].ToString();
                        user_TB.Text = dt.Rows[0]["Member_Id"].ToString();
                    }
                    else
                    {
                        Response.Write("<script> alert(' INVALID ID '); </script>");
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
            discIDTB.Text = "";
            title_TB.Text = "";
            content_TB.Text = "";
            DS_TB.Text = "";
            DC_TB.Text = "";
            user_TB.Text = "";
        }

        private void deleteDiscussion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "DELETE FROM Discussion WHERE Discussion_Id = @d_Id";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@d_Id", discIDTB.Text.Trim());

                    int rowsAffected = cmd1.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        GridView1.DataBind();
                        Response.Write("<script> alert('Discussion Deleted Successfully.'); </script>");
                    }
                    else
                    {
                        Response.Write("<script> alert('Failed To Delete Discussion.'); </script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void updateStatus(string status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "UPDATE Discussion SET Status = '" + status + "' WHERE Discussion_Id = @d_Id";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@d_Id", discIDTB.Text.Trim());

                    int rowsAffected = cmd1.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Successful update
                        DS_TB.Text = status;
                        Response.Write("<script> alert('Status Updated successfully.'); </script>");
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("<script> alert('Failed to Update Status.'); </script>");
                    }
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            searchbyID();
        }

        protected void ActiveBtn_Click(object sender, EventArgs e)
        {
            updateStatus("Active");
        }

        protected void DisableBtn_Click(object sender, EventArgs e)
        {
            updateStatus("Disabled");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            deleteDiscussion();
        }
    }
}