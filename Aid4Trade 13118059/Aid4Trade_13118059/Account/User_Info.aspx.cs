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
    public partial class User_Info : System.Web.UI.Page
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
            DataTable dt_user_data = this.GetData("Select * from product_comment_and_user_info where [User ID] = '" + this.Page.RouteData.Values["userID"].ToString() + "'");
            DataTable dt_products = this.GetData("select [Product name],count([Product ID]) [Count Of Comments], [Product ID] from product_comment_and_user_info where [User ID] = '" + this.Page.RouteData.Values["userID"].ToString() + "' group by [Product name], [Product ID]");
            userDetail.DataSource = dt_user_data;
            userDetail.DataBind();
            show_comments.DataSource = dt_products;
            show_comments.DataBind();
        }
        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
    }
}