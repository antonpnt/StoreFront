using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using StoreFront.Data;

namespace Week3Assignment
{
    //Simple web application that tests the connection to the Inventory Web Service methods
    public partial class ClientInventoryTest : System.Web.UI.Page
    {
        //Connects to the inventory web service
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();   

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //Searches for products on button click based on the input string entered in the text box
        protected void Button1_Click(object sender, EventArgs e)
        {
            string searchString = TextBox1.Text;

            GridView1.DataSource = client.SearchProducts(searchString);
            GridView1.DataBind();

        }

        //Gets product details on button click based on the input id entered in the text box 
        protected void Button2_Click(object sender, EventArgs e)
        {
            string id = TextBox2.Text;

            //If something was entered in the text box
            if(id != null)
            {
                var prod = client.GetProductDetails(Convert.ToInt32(id));
                var list = new List<Product> { prod };
                GridView2.DataSource = list;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }



        }
    }
}