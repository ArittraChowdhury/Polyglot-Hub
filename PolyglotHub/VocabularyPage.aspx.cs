using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PolyglotHub
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the Label in the ItemTemplate
                Label labelNumber = (Label)e.Row.FindControl("NumLabel");

                // Set the text of the Label to the row index plus 1
                labelNumber.Text = (e.Row.RowIndex + 1).ToString();
            }
        }
        protected void LevelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind(); // Rebind the GridView to update the data based on the selected level ID
        }
    }
}