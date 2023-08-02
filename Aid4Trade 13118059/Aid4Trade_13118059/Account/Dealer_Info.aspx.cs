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
    public partial class Dealer_Info : System.Web.UI.Page
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
            DataTable dt = this.GetData("Select * from product_details_and_dealer_info where [Dealer ID] = '" + this.Page.RouteData.Values["dealerID"].ToString() + "' and [Product status] = 'Approved'");
            dealerDetail.DataSource = dt;
            dealerDetail.DataBind();
            show_products.DataSource = dt;
            show_products.DataBind();
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

        protected void dealerDetail_ItemCreated(object sender, EventArgs e)
        {
            DataTable dt = this.GetData("Select * from product_details_and_dealer_info where [Dealer ID] = '" + this.Page.RouteData.Values["dealerID"].ToString() + "' and [Product status] = 'Approved'");
            Label label = (Label)dealerDetail.FindControl("rating");
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["Rating value"]) >= 0 && Convert.ToInt32(row["Rating value"]) <= 2)
                {
                    label.ForeColor = System.Drawing.Color.DarkRed;
                    label.Text = "Нисък рейтинг";
                }
                if (Convert.ToInt32(row["Rating value"]) > 2 && Convert.ToInt32(row["Rating value"]) <= 4)
                {
                    label.ForeColor = System.Drawing.Color.Orange;
                    label.Text = "Добър рейтинг";
                }
                if (Convert.ToInt32(row["Rating value"]) > 4 && Convert.ToInt32(row["Rating value"]) <= 6)
                {
                    label.ForeColor = System.Drawing.Color.DarkGreen;
                    label.Text = "Висок рейтинг";
                }
            }
        }
    }
}