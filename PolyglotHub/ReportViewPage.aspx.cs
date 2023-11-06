using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PolyglotHub
{
    public partial class WebForm32 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnChart_Click(object sender, EventArgs e)
        {
            // Get the selected category and chart type.
            string selectedCategory = CategList.SelectedValue.Trim();
            string selectedChartType = chartRBList.SelectedValue.Trim();

            var data = getChartData(selectedCategory);

            if (data.Rows.Count > 0)
            {
                // Bind the chart data and display the chart.
                BindChart(data);
                messageLbl.Text = string.Empty; // Clear any previous error messages.
            }
            else
            {
                // Show an error message if the DataTable is empty.
                divChart.Visible = false; // Hide the chart container.
                messageLbl.Text = "No data available for the selected category.";
            }
        }

        private DataTable getChartData(string category)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    if (category.Equals("TestByLevel"))
                    {

                        using (SqlCommand cmd = new SqlCommand("SELECT lt.Name, COUNT(t.ReadingTest_Id) AS TestCount FROM ReadingTest t " +
                            "JOIN LevelTable lt ON t.Level_Id = lt.Level_Id GROUP BY lt.Name", con))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                    }
                    else if (category.Equals("GrammarByLevel"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT lt.Name, COUNT(gt.Grammar_Id) AS GrammarCount FROM GrammarTable gt " +
                            "JOIN LevelTable lt ON gt.Level_Id = lt.Level_Id GROUP BY lt.Name", con))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                    }
                    else if (category.Equals("VocabularyByLevel"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT lt.Name, COUNT(v.VocabularyWord_Id) AS WordCount FROM VocabularyWord v " +
                            "JOIN LevelTable lt ON v.Level_Id = lt.Level_Id GROUP BY lt.Name", con))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                    }
                    else if (category.Equals("QuestionByLevel"))
                    {
                        string q = "SELECT lt.Name AS levelName, COUNT(qt.Question_Id) AS QuestionCount FROM LevelTable lt " +
                            "JOIN ReadingTest rt ON lt.Level_Id = rt.Level_Id " +
                            "JOIN QuestionTable qt ON rt.ReadingTest_Id = qt.ReadingTest_Id " +
                            "GROUP BY lt.Name";
                        using (SqlCommand cmd = new SqlCommand(q, con))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                    }
                    else if (category.Equals("DiscussionByStatus"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT Status, COUNT(*) FROM Discussion GROUP BY Status", con))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                    }
                    else if (category.Equals("MemberByStatus"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT LoginStatus, COUNT(*) FROM MemberTable GROUP BY LoginStatus", con))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                    }
                }
                return dt;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
                return dt;
            }


        }

        private void BindChart(DataTable data)
        {
            if (data.Rows.Count > 0)
            {
                // Get the column names dynamically from the DataTable.
                string dataXValueColumn = data.Columns[0].ColumnName;
                string dataYValueColumn = data.Columns[1].ColumnName;

                // Clear existing data points.
                chartComp.Series["Count"].Points.Clear();

                // Add data points to the series and set the legend text dynamically.
                Random random = new Random();
                foreach (DataRow row in data.Rows)
                {
                    string levelName = row[dataXValueColumn].ToString();
                    int count = Convert.ToInt32(row[dataYValueColumn]);

                    // Add the data point to the series.
                    DataPoint dataPoint = chartComp.Series["Count"].Points.Add(count);
                    dataPoint.AxisLabel = levelName;
                    dataPoint.LegendText = $"{levelName} : {count}";
                    Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    dataPoint.Color = randomColor;

                }

                // Set the chart type based on the selected value from the RadioButtonList.
                string selectedChartType = chartRBList.SelectedValue;
                chartComp.Series["Count"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), selectedChartType);

                // Show the chart container.
                divChart.Visible = true;

                // Add a legend to the chart for the pie chart only.
                if (chartComp.Series["Count"].ChartType == SeriesChartType.Pie)
                {
                    chartComp.Legends.Clear();
                    chartComp.Legends.Add(new Legend("MyLegend")
                    {
                        Docking = Docking.Bottom,
                        Alignment = StringAlignment.Center,
                        IsDockedInsideChartArea = false,
                        LegendStyle = LegendStyle.Table
                    });

                    // Set the legend to show for each data point.
                    chartComp.Series["Count"].IsVisibleInLegend = true;
                    chartComp.Series["Count"].Legend = "MyLegend";
                }
                else
                {
                    // Hide the legend for non-pie charts.
                    chartComp.Legends.Clear();
                    chartComp.Series["Count"].IsVisibleInLegend = false;
                }
            }
        }
    }
}