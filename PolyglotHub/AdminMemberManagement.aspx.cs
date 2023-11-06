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
    public partial class WebForm8 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button10_Click(object sender, EventArgs e) // Search Button
        {
            searchMember();
        }

        protected void ActiveBtn_Click(object sender, EventArgs e)
        {
            updateStatus("Active");
        }

        protected void DisableBtn_Click(object sender, EventArgs e)
        {
            updateStatus("Disabled");
        }

        void updateStatus(string status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "UPDATE MemberTable SET LoginStatus = '"+ status +"' WHERE Member_Id = @member_Id";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@member_Id", MID_TB.Text.Trim());
                    
                    int rowsAffected = cmd1.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Successful update
                        AS_TB.Text = status;
                        Response.Write("<script> alert('Status Updated successfully.'); </script>");
                    } else
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

        void searchMember()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "SELECT * FROM MemberTable WHERE Member_Id = @member_Id";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@member_Id", MID_TB.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        FN_TB.Text = dt.Rows[0]["FirstName"].ToString();
                        LN_TB.Text = dt.Rows[0]["LastName"].ToString();
                        AS_TB.Text = dt.Rows[0]["LoginStatus"].ToString();
                        DJ_TB.Text = dt.Rows[0]["DateJoined"].ToString();
                        UN_TB.Text = dt.Rows[0]["Username"].ToString();
                        PW_TB.Text = dt.Rows[0]["Password"].ToString();
                        Country_TB.Text = dt.Rows[0]["Country"].ToString();
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

        void clearInput()
        {
            FN_TB.Text = "";
            LN_TB.Text = "";
            AS_TB.Text = "";
            DJ_TB.Text = "";
            UN_TB.Text = "";
            PW_TB.Text = "";
            Country_TB.Text = "";
        }

        protected void Button7_Click(object sender, EventArgs e) // Delete Member
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string q1 = "DELETE FROM MemberTable WHERE Member_Id = @member_Id";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@member_Id", MID_TB.Text.Trim());

                    int rowsAffected = cmd1.ExecuteNonQuery();
                    if(rowsAffected>0)
                    {
                        GridView1.DataBind();
                        Response.Write("<script> alert('Member Deleted Successfully.'); </script>");
                    } else
                    {
                        Response.Write("<script> alert('Failed To Delete Member.'); </script>");
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