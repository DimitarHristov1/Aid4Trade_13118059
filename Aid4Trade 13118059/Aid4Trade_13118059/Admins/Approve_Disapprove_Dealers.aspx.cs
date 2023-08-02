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
    public partial class Approve_Disapprove_Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Dealer") || User.IsInRole("User"))
            {
                Response.Redirect(GetRouteUrl("Home", null));
            }
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            dealers_dridview.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        private void BindGrid()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Dealers"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dealers_dridview.DataSource = dt;
                            dealers_dridview.DataBind();
                        }
                    }
                }
            }
        }

        protected void dealers_dridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[5];
                TableCell cell_6 = e.Row.Cells[6];
                HyperLink navigate = (HyperLink)e.Row.Cells[7].FindControl("navigate");
                string status = cell.Text;
                string status_role = cell_6.Text;
                if (status_role == "Admin")
                {
                    cell_6.Text = "Админ";
                }
                if (status_role == "Dealer")
                {
                    cell_6.Text = "Търговец";
                }
                if (status == "Approved")
                {
                    cell.Text = "Одобрен";
                    cell.ForeColor = System.Drawing.Color.Green;
                }
                if (status == "Not Approved")
                {
                    cell.Text = "Неодобрен";
                    cell.ForeColor = System.Drawing.Color.Red;
                }
                if (status == "Registered")
                {
                    cell.Text = "Изчаква одобрение";
                    cell.ForeColor = System.Drawing.Color.Blue;
                    navigate.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}