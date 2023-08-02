using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Account
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindListView();
            }
        }
        private void BindListView()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM product_list where [Category name] = '" + this.Page.RouteData.Values["categoryName"].ToString() + "' and [Product status] = 'Approved'";
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        productList.DataSource = dt;
                        productList.DataBind();
                    }
                }
            }
        }
    }
}