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
    public partial class WebForm4 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string q1 = "SELECT * FROM AdminTable WHERE Username='" + TextBox1.Text.Trim() + "' AND Password='" + TextBox2.Text.Trim() + "'";
                SqlCommand cmd1 = new SqlCommand(q1, con);
                // Connected Architecture -> DR will still be connected to DB to the data table
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows) // Give true or false depends on record coming in or not
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login Success!'); window.location='Default.aspx';</script>"); //  if all condition are true
                        Session["username"] = dr.GetValue(1).ToString();
                        Session["role"] = "Admin";
                    }
                }
                else
                {
                    errLabel1.Visible = true;
                    errLabel1.Text = "Username/Password Not Found!";
                }

            }
            catch (Exception ex)
            {
                errLabel1.Visible = true;
                errLabel1.Text = "Login Error, Contact Admin! " + ex.ToString();
            }
        }
    }
}