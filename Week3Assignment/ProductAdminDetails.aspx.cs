using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Week3Assignment
{
    public partial class ProductAdminDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=B1VF9W1\\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//ProductImages//" + str);
                string path = "~//ProductImages//" + str.ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into products (ImageFile) values('" + path + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Image upload successful";

            }
            else
            {
                Label1.Text = "Please upload an image";
            }

        }
    }
}