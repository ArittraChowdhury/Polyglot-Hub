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
    public partial class WebForm33 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(NP_TB.Text.Trim().Equals("") || FN_TB.Text.Trim().Equals("") || LN_TB.Text.Trim().Equals("") || user_TB.Text.Trim().Equals(""))
                {
                    errLabel1.Visible = true;
                    errLabel1.Text = "ALL field must be filled!";
                } else
                {
                    int flag = 0;
                    string temp_id = "";
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM MemberTable WHERE Username = @username", con))
                        {
                            cmd1.Parameters.AddWithValue("@username", user_TB.Text.Trim());
                            SqlDataAdapter da = new SqlDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                if (FN_TB.Text.Trim().Equals(dt.Rows[0]["FirstName"].ToString()) && LN_TB.Text.Trim().Equals(dt.Rows[0]["LastName"].ToString()))
                                {
                                    flag = 1;
                                    temp_id = dt.Rows[0]["Member_Id"].ToString();
                                }
                            }
                            if (flag == 0)
                            {
                                errLabel1.Visible = true;
                                errLabel1.Text = "No Such Account was found";
                            }
                        }
                        if (flag == 1)
                        {
                            using (SqlCommand cmd2 = new SqlCommand("UPDATE MemberTable SET Password = @pw WHERE Member_Id = @mid", con))
                            {
                                cmd2.Parameters.AddWithValue("@pw", NP_TB.Text.Trim());
                                cmd2.Parameters.AddWithValue("@mid", temp_id);
                                int rowsAffected = cmd2.ExecuteNonQuery();
                                if(rowsAffected>0)
                                {
                                    Response.Write("<script>alert('Password Reset Success!'); window.location='LoginPage.aspx';</script>");
                                    user_TB.Text = "";
                                    FN_TB.Text = "";
                                    LN_TB.Text = "";
                                    NP_TB.Text = "";
                                } else
                                {
                                    Response.Write("<script>alert('Password Reset Fail!')</script>");
                                }
                                
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                errLabel1.Visible = true;
                errLabel1.Text = ex.Message;
            }
        }
    }
}