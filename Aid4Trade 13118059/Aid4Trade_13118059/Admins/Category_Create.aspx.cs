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
    public partial class Category_Create : System.Web.UI.Page
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

        protected void Create_Click(object sender, EventArgs e)
        {
            int msg = 0;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("create_category", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryName", category_name_input.Value);
                    cmd.Parameters.AddWithValue("@CategoryDescription", category_description_input.Value);
                    cmd.Parameters.Add("@msg", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    msg = (int)cmd.Parameters["@msg"].Value;
                }
                if (msg == -1)
                {
                    category_created.ForeColor = System.Drawing.Color.Green;
                    category_created.Visible = false;
                    category_exists.ForeColor = System.Drawing.Color.Red;
                    category_exists.Visible = true;
                    return;
                }
                if (msg == 1)
                {
                    category_exists.ForeColor = System.Drawing.Color.Red;
                    category_exists.Visible = false;
                    this.BindListView();
                    category_created.ForeColor = System.Drawing.Color.Green;
                    category_created.Visible = true;
                    return;
                }
            }
        }
        private void BindListView()
        {
            DataTable categories_exist = this.GetData("SELECT [Category ID], [Category name],[Category description] FROM [Categories]");
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
                        categoryList.DataSource = dt;
                        categoryList.DataBind();
                    }
                }
                return dt;
            }
        }
    }
}