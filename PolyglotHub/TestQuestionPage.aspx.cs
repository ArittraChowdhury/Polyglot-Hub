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
   
    public partial class WebForm20 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        int TID = 0;
        string testContent = "";
        RadioButtonList choiceList;

        List<string> questionList = new List<string>();
        List<string> answerList = new List<string>();
        List<RadioButtonList> choiceLists = new List<RadioButtonList>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    scoreLabel.Visible = false;
                    ReturnBtn.Visible = false;
                    if (Request.QueryString["ReadingTestID"] != null)
                    {
                        string testId = Request.QueryString["ReadingTestID"];
                        TID = Convert.ToInt32(testId);
                        Session["TID"] = TID;
                    }
                }
                else
                {
                    TID = Convert.ToInt32(Session["TID"].ToString());
                }
                GenerateQuestionItems();
            } catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }  
        }

        private void GenerateQuestionItems()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strcon))
                {

                    int i = 1;
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand("SELECT * FROM QuestionTable WHERE ReadingTest_Id = '"+TID+"'", connection))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM ReadingTest WHERE ReadingTest_Id = @TestId", connection);
                        cmd.Parameters.AddWithValue("@TestId", TID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if(dt.Rows.Count>0)
                        {
                            testContent = dt.Rows[0]["TestText"].ToString();
                            TextLabel.Text = testContent;
                        }
                                               
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["Content"].ToString();
                                string c1 = reader["FirstChoice"].ToString();
                                string c2 = reader["SecondChoice"].ToString();
                                string c3 = reader["ThirdChoice"].ToString();
                                string ans = reader["Answer"].ToString();
                                Session["answer"] = reader["Answer"].ToString();

                                questionList.Add(title);
                                answerList.Add(ans);


                                Panel flexItem = new Panel();
                                flexItem.CssClass = "card-body";

                                

                                Literal literal = new Literal();
                                literal.Text = "<div> Question " + i + ".</div>";
                                flexItem.Controls.Add(literal);
                                i++;

                                var titleElement = new HtmlGenericControl("h6");
                                titleElement.InnerText = title;
                                flexItem.Controls.Add(titleElement);

                                // Create a RadioButtonList control for the choices
                                choiceList = new RadioButtonList();
                                choiceList.ID = "ChoiceList_" + i;
                                choiceList.CssClass = "choice-list";


                                // Add the choices as list items to the RadioButtonList
                                choiceList.Items.Add(new ListItem("A. " + c1, c1));
                                choiceList.Items.Add(new ListItem("B. " + c2, c2));
                                choiceList.Items.Add(new ListItem("C. " + c3, c3));

                                choiceLists.Add(choiceList);
                                // Add the RadioButtonList to the flexItem
                                flexItem.Controls.Add(choiceList);

                                HtmlGenericControl hr = new HtmlGenericControl("hr");
                                hr.Attributes["class"] = "custom-hr";
                                flexItem.Controls.Add(hr);

                                // Find the master page instance
                                var masterPage = Page.Master as Layout;

                                // Find the class within the content placeholder on the master page
                                var flexbox = masterPage.FindControl("ContentPlaceHolder1").FindControl("flexbox") as HtmlGenericControl;

                                if (flexbox != null)
                                {
                                    // Add the flex-item to the flexbox container
                                    flexbox.Controls.Add(flexItem);
                                }
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
        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            List<string> selectedValues = new List<string>();
            int CorrectQ = 0;
            int WrongQ = 0;

            int size = questionList.Count();

            for (int i = 0; i < size; i++)
            {

                // Find the RadioButtonList within the flex-item
                RadioButtonList choiceList = choiceLists[i];

                if (choiceList != null)
                {
                    // Get the selected value from the RadioButtonList
                    string selectedValue = choiceList.SelectedValue;

                    if (selectedValue.Equals(answerList[i]))
                    {
                        CorrectQ++;
                        CreateLabel(i + 1, "Correct", answerList[i]);
                    } else
                    {
                        WrongQ++;
                        CreateLabel(i + 1, "Wrong", answerList[i]);
                    }
                }     
            }
            scoreLabel.Visible = true;
            scoreLabel.Text = "Score : "+ CorrectQ +"/" + (CorrectQ+WrongQ);
            CheckBtn.Visible = false;

            ReturnBtn.Visible = true;
        }

        protected void ReturnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SampleTestPage.aspx");
        }

        private void CreateLabel(int questionNumber, string status, string correctAnswer)
        {
            Label label = new Label();
            label.Text = $"Question {questionNumber}. Answer: {status}. {correctAnswer}<br/>";
            // You can further customize label properties like style, positioning, etc.
            // For example:
            label.CssClass = "answer-label"; // Apply CSS class
            label.Attributes.Add("style", "margin-bottom: 10px;"); // Add inline style

            // Add the label to a suitable container (e.g., a Panel)
            var masterPage = Page.Master as Layout;

            // Find the class within the content placeholder on the master page
            var flexbox = masterPage.FindControl("ContentPlaceHolder1").FindControl("flexbox") as HtmlGenericControl;

            if (flexbox != null)
            {
                flexbox.Controls.Add(label);
            }
        }
    }
}