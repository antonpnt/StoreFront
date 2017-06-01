using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week3Assignment
{
    public partial class ProductsAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Redirect("~/ProductAdminDetails.aspx?ProductID=" + e.CommandArgument);
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void DetailsView1_PageIndexChanging1(object sender, DetailsViewPageEventArgs e)
        {

        }
    }
}