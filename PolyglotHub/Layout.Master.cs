using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PolyglotHub
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null || Session["role"].Equals(""))
                {
                    Session["role"] = "Guest";
                }
                if (Session["role"].Equals("Guest")) // If no user login
                {
                    LinkButton4.Visible = true; // Login Button
                    LinkButton3.Visible = true; // Sign Up Button

                    ReportBtn.Visible = false; // admin report btn
                    forumBtn.Visible = false; // user forum btn
                    LinkButton12.Visible = false; // Grammar
                    LinkButton6.Visible = false; // Sample Test
                    LinkButton1.Visible = false; // Log Out
                    LinkButton2.Visible = false; // Hello User
                    LinkButton5.Visible = false; // Admin Level
                    LinkButton7.Visible = false; // Admin Question
                    LinkButton8.Visible = false; // Admin Vocab
                    LinkButton9.Visible = false; // Admin Forum
                    LinkButton10.Visible = false; // Admin Member
                    LinkButton11.Visible = false; // Admin Test
                }
                else if (Session["role"].Equals("Member") && Session["status"].Equals("Active"))
                {
                    LinkButton4.Visible = false; // Login Button
                    LinkButton3.Visible = false; // Sign Up Button

                    ReportBtn.Visible = false; // admin report btn
                    LinkButton1.Visible = true; // Log Out
                    LinkButton2.Visible = true; // Hello User
                    LinkButton2.Text = "Hello " + Session["firstname"].ToString() + " " + Session["lastname"].ToString();

                    forumBtn.Visible = true; // user forum btn
                    LinkButton12.Visible = true; // Grammar
                    LinkButton6.Visible = true; // Sample Test
                    LinkButton5.Visible = false; // Admin Level
                    LinkButton7.Visible = false; // Admin Question
                    LinkButton8.Visible = false; // Admin Vocab
                    LinkButton9.Visible = false; // Admin Forum
                    LinkButton10.Visible = false; // Admin Member
                    LinkButton11.Visible = false; // Admin Test
                }
                else if (Session["role"].Equals("Member"))
                {
                    if (Session["status"].Equals("Disabled"))
                    {
                        Response.Write("<script> alert('Account Status is Disabled! " +
                        "Contact Admin for further Assitance'); </script>");
                    } else if(Session["role"].Equals("Member") && Session["status"].Equals("Pending"))
                    {
                        Response.Write("<script> alert('Account is Waiting for Activation! " +
                        "Contact Admin for further Assitance'); </script>");
                    }
                    Session["MemberID"] = "";
                    Session["username"] = "";
                    Session["firstname"] = "";
                    Session["lastname"] = "";
                    Session["role"] = "";
                    Session["status"] = "";


                    ReportBtn.Visible = false; // admin report btn
                    LinkButton4.Visible = true; // Login Button
                    LinkButton3.Visible = true; // Sign Up Button
                    forumBtn.Visible = false; // user forum btn
                    LinkButton12.Visible = false; // Grammar
                    LinkButton6.Visible = false; // Sample Test
                    LinkButton1.Visible = false; // Log Out
                    LinkButton2.Visible = false; // Hello User
                    LinkButton5.Visible = false; // Admin Level
                    LinkButton7.Visible = false; // Admin Question
                    LinkButton8.Visible = false; // Admin Vocab
                    LinkButton9.Visible = false; // Admin Forum
                    LinkButton10.Visible = false; // Admin Member
                    LinkButton11.Visible = false; // Admin Test
                }
                
                else if (Session["role"].Equals("Admin"))
                {
                    LinkButton4.Visible = false; // Login Button
                    LinkButton3.Visible = false; // Sign Up Button

                    LinkButton1.Visible = true; // Log Out
                    LinkButton2.Visible = true; // Hello User
                    LinkButton2.Text = "Hello Admin " + Session["username"].ToString();

                    ReportBtn.Visible = true; // admin report btn
                    LinkButton12.Visible = true; // Grammar
                    LinkButton6.Visible = true; // Sample Test
                    LinkButton5.Visible = true; // Admin Level
                    LinkButton7.Visible = true; // Admin Question
                    LinkButton8.Visible = true; // Admin Vocab
                    LinkButton9.Visible = true; // Admin Forum
                    LinkButton10.Visible = true; // Admin Member
                    LinkButton11.Visible = true; // Admin Test
                } 
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["MemberID"] = "";
            Session["username"] = "";
            Session["firstname"] = "";
            Session["lastname"] = "";
            Session["role"] = "";
            Session["status"] = "";


            LinkButton4.Visible = true; // Login Button
            LinkButton3.Visible = true; // Sign Up Button

            ReportBtn.Visible = false; // admin report btn
            LinkButton12.Visible = false; // Grammar
            LinkButton6.Visible = false; // Sample Test
            LinkButton1.Visible = false; // Log Out
            LinkButton2.Visible = false; // Hello User
            LinkButton5.Visible = false; // Admin Level
            LinkButton7.Visible = false; // Admin Question
            LinkButton8.Visible = false; // Admin Vocab
            LinkButton9.Visible = false; // Admin Forum
            LinkButton10.Visible = false; // Admin Member
            LinkButton11.Visible = false; // Admin Test

            Response.Redirect("LoginPage.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLvlManage.aspx");
        }


        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminQuestionManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminVocabularyManagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e) // Forum Management Page
        {
            Response.Redirect("AdminForumManagement.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagement.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminTestManagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("SampleTestPage.aspx");
        }

        protected void forumBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForumPage.aspx");
        }

        protected void ReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportViewPage.aspx");
        }
    }
}