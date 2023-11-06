using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace PolyglotHub
{
    public partial class WebForm26 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        int DID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["DiscID"] != null)
                    {
                        string Id = Request.QueryString["DiscID"];
                        DID = Convert.ToInt32(Id);
                        Session["DID"] = DID;
                        HiddenLabel.Text = "" + DID;
                    }
                    getTitle();
                    bool isActive = isStatusActive();
                    CommentTB.Enabled = isActive;
                    SendBtn.Enabled = isActive;
                    StatusLabel.Visible = !isActive;
                }
                else
                {
                    DID = Convert.ToInt32(Session["DID"].ToString());
                }
                GridView1.DataBind();
            } catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
            
        }

        private bool isStatusActive()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Discussion WHERE Discussion_Id = @discussionId",con))
                    {
                        cmd.Parameters.AddWithValue("@discussionId", DID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            string currentStatus = dt.Rows[0]["Status"].ToString();
                            if (currentStatus.Equals("Active"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
                return false;
            }
        }

        protected string GetMemberName(object memberId)
        {
            if (memberId != null)
            {
                int memberIdValue = Convert.ToInt32(memberId);

                try
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM MemberTable WHERE Member_Id = '" + memberIdValue + "'", con))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                return dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                }
            }
            return string.Empty;
        }

        protected void SendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "INSERT INTO CommentTable (CommentText, Date_Created, Discussion_Id, Member_Id)" +
                        "VALUES (@comment, @date, @did, @mid) ";
                    using (SqlCommand cmd = new SqlCommand(q1,con))
                    {
                        DateTime today = DateTime.Now.Date;
                        cmd.Parameters.AddWithValue("@comment",CommentTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@date", today.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@did", DID);
                        cmd.Parameters.AddWithValue("@mid", Session["MemberID"]);
                        int rowAffected = cmd.ExecuteNonQuery();
                        if(rowAffected>0)
                        {
                            CommentTB.Text = "";
                        }
                        GridView1.DataBind();
                    }
                }
            } catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        private void getTitle()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string q1 = "SELECT * FROM Discussion WHERE Discussion_Id = @discussion_Id";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                    {
                        cmd.Parameters.AddWithValue("@discussion_Id", DID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if(dt.Rows.Count>0)
                            {
                                TextLabel.Text = dt.Rows[0]["Title"].ToString();
                                ContentLabel.Text = dt.Rows[0]["Content"].ToString();
                            } else
                            {
                                Response.Write("<script> alert(' ID INVALID '); </script>");
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
    }

}