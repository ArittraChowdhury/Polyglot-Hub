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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Submit/ Signup Button Clicked
        protected void Button1_Click(Object sender, EventArgs e)
        {
            if(TextBox3.Text.Equals("") || TextBox4.Text.Equals("") || TextBox1.Text.Equals("") || TextBox2.Text.Equals("") || TextBox6.Text.Equals(""))
            {
                errLabel2.Text = "ALL Field must be filled !";
                errLabel2.Visible = true;
            } else
            {
                errLabel2.Visible = false;
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed) //  If connection is closed, Open it
                    {
                        con.Open();
                    }

                    string q1 = "SELECT COUNT(*) FROM MemberTable WHERE Username = '" + TextBox1.Text.Trim() + "'"; // Check for Username Status
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    int check = Convert.ToInt32(cmd1.ExecuteScalar().ToString());

                    if (check > 0)
                    {
                        errLabel1.Visible = true;
                        errLabel1.Text = "Username has been Used!";
                    }
                    else
                    {
                        if (DropDownList1.SelectedItem.Value == "select")
                        {
                            errLabel3.Visible = true;
                            errLabel3.Text = "Select your country!";
                        }
                        else
                        {
                            string q2 = "INSERT INTO MemberTable (Username,Password,FirstName,LastName,Country,DateJoined,LoginStatus)" +
                                "VALUES (@Username,@Password,@FirstName,@LastName,@Country,@DateJoined,@LoginStatus)";
                            SqlCommand cmd2 = new SqlCommand(q2, con);
                            DateTime today = DateTime.Now.Date;

                            cmd2.Parameters.AddWithValue("@FirstName", TextBox3.Text.Trim());
                            cmd2.Parameters.AddWithValue("@LastName", TextBox4.Text.Trim());
                            cmd2.Parameters.AddWithValue("@Country", DropDownList1.SelectedItem.Value);
                            cmd2.Parameters.AddWithValue("@Username", TextBox1.Text.Trim());
                            cmd2.Parameters.AddWithValue("@Password", TextBox2.Text.Trim());
                            cmd2.Parameters.AddWithValue("@DateJoined", today.ToString("yyyy-MM-dd"));
                            cmd2.Parameters.AddWithValue("@LoginStatus", "Pending");

                            cmd2.ExecuteNonQuery();
                            Response.Write("<script>alert('Sign Up Success!'); window.location='LoginPage.aspx';</script>");
                        }
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    errLabel2.Visible = true;
                    errLabel2.Text = "Registration Failed!" + ex.ToString(); // need to check
                }
            }
            
        }
    }
}