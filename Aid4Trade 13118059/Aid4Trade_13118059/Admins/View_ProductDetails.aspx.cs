using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Admins
{
    public partial class View_ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Dealer") || User.IsInRole("User"))
            {
                Response.Redirect(GetRouteUrl("Home", null));
            }
            if (!this.IsPostBack)
            {
                this.BindListView();
            }
        }
        private void BindListView()
        {
            DataTable dt = this.GetData("Select * from product_details_and_dealer_info where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "'");
            if (dt.Rows[0]["Product status"].ToString() == "Approved" || dt.Rows[0]["Product status"].ToString() == "Not Approved")
            {
                approve.Visible = false;
                disapprove.Visible = false;
            }
            if (dt.Rows[0]["Product status"].ToString() == "Registered")
            {
                approve.Visible = true;
                disapprove.Visible = true;
            }
            productDetail.DataSource = dt;
            productDetail.DataBind();
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

        protected void productDetail_ItemCreated(object sender, EventArgs e)
        {
            DataTable dt = this.GetData("Select * from product_details_and_dealer_info where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "'");
            Label no_price = (Label)productDetail.FindControl("no_price");
            Label status = (Label)productDetail.FindControl("status");
            var price = productDetail.FindControl("price");
            if (dt.Rows[0]["Product status"].ToString() == "Approved")
            {
                status.ForeColor = System.Drawing.Color.Green;
                status.Text = "Одобрен";
            }
            if (dt.Rows[0]["Product status"].ToString() == "Not Approved")
            {
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = "Неодобрен";
            }
            if (dt.Rows[0]["Product status"].ToString() == "Registered")
            {
                status.ForeColor = System.Drawing.Color.Blue;
                status.Text = "Изчаква одобрение";
            }
            foreach (DataRow row in dt.Rows)
            {
                if (!DBNull.Value.Equals(row["Product price"]))
                {
                    price.Visible = true;
                    no_price.Visible = false;
                }
                else
                {
                    no_price.ForeColor = System.Drawing.Color.Red;
                    price.Visible = false;
                    no_price.Text = "Не е зададена цена за конкретния продукт";
                }
            }
        }

        protected void approve_Click(object sender, EventArgs e)
        {
            Label status = (Label)productDetail.FindControl("status");
            string confirmValue = Request.Form["confirm_value_approve"];
            Label result = (Label)productDetail.FindControl("result");
            var result_link = productDetail.FindControl("result_link");
            if (confirmValue == "Да")
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Products set [Product status] = 'Approved' where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                status.ForeColor = System.Drawing.Color.Green;
                status.Text = "Одобрен";
                result.ForeColor = System.Drawing.Color.Green;
                result.Text = "Продуктът е одобрен.";
                approve.Visible = false;
                disapprove.Visible = false;
                result.Visible = true;
                result_link.Visible = true;
            }
            else
            {
                return;
            }
        }

        protected void disapprove_Click(object sender, EventArgs e)
        {
            Label status = (Label)productDetail.FindControl("status");
            string confirmValue = Request.Form["confirm_value_disapprove"];
            Label result = (Label)productDetail.FindControl("result");
            var result_link = productDetail.FindControl("result_link");
            if (confirmValue == "Да")
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Products set [Product status] = 'Not Approved' where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = "Неодобрен";
                result.ForeColor = System.Drawing.Color.Red;
                result.Text = "Продуктът е неодобрен.";
                approve.Visible = false;
                disapprove.Visible = false;
                result.Visible = true;
                result_link.Visible = true;
            }
            else
            {
                return;
            }
        }
    }
}