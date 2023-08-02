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
    public partial class View_DealerDetails : System.Web.UI.Page
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
            DataTable dt = this.GetData("Select * from Dealers where [Dealer ID] = '" + this.Page.RouteData.Values["dealerID"].ToString() + "'");
            if (dt.Rows[0]["Dealer status"].ToString() == "Approved" || dt.Rows[0]["Dealer status"].ToString() == "Not Approved")
            {
                approve.Visible = false;
                disapprove.Visible = false;
            }
            if (dt.Rows[0]["Dealer status"].ToString() == "Registered")
            {
                approve.Visible = true;
                disapprove.Visible = true;
            }
            dealerDetail.DataSource = dt;
            dealerDetail.DataBind();
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
            DataTable dt = this.GetData("Select * from Dealers where [Dealer ID] = '" + this.Page.RouteData.Values["dealerID"].ToString() + "'");
            Label label = (Label)dealerDetail.FindControl("rating");
            Label status = (Label)dealerDetail.FindControl("status");
            Label role = (Label)dealerDetail.FindControl("role");
            if (dt.Rows[0]["Dealer status"].ToString() == "Approved")
            {
                status.ForeColor = System.Drawing.Color.Green;
                status.Text = "Одобрен";
            }
            if (dt.Rows[0]["Dealer status"].ToString() == "Not Approved")
            {
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = "Неодобрен";
            }
            if (dt.Rows[0]["Dealer status"].ToString() == "Registered")
            {
                status.ForeColor = System.Drawing.Color.Blue;
                status.Text = "Изчаква одобрение";
            }
            if (dt.Rows[0]["Dealer role"].ToString() == "Admin")
            {
                approve.Visible = false;
                disapprove.Visible = false;
                role.ForeColor = System.Drawing.Color.Red;
                role.Text = "Админ";
            }
            if (dt.Rows[0]["Dealer role"].ToString() == "Dealer")
            {
                role.ForeColor = System.Drawing.Color.Green;
                role.Text = "Търговец";
            }
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

        protected void approve_Click(object sender, EventArgs e)
        {
            Label status = (Label)dealerDetail.FindControl("status");
            string confirmValue = Request.Form["confirm_value_approve"];
            Label result = (Label)dealerDetail.FindControl("result");
            var result_link = dealerDetail.FindControl("result_link");
            if (confirmValue == "Да")
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Dealers set [Dealer status] = 'Approved' where [Dealer ID] = '" + this.Page.RouteData.Values["dealerID"].ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                status.ForeColor = System.Drawing.Color.Green;
                status.Text = "Одобрен";
                result.ForeColor = System.Drawing.Color.Green;
                result.Text = "Търговецът е одобрен.";
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
            Label status = (Label)dealerDetail.FindControl("status");
            string confirmValue = Request.Form["confirm_value_disapprove"];
            Label result = (Label)dealerDetail.FindControl("result");
            var result_link = dealerDetail.FindControl("result_link");
            if (confirmValue == "Да")
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Dealers set [Dealer status] = 'Not Approved' where [Dealer ID] = '" + this.Page.RouteData.Values["dealerID"].ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                status.ForeColor = System.Drawing.Color.Red;
                status.Text = "Неодобрен";
                result.ForeColor = System.Drawing.Color.Red;
                result.Text = "Търговецът е неодобрен.";
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