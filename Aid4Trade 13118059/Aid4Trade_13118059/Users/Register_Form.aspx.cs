using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Users
{
    public partial class Register_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void reg_Click(object sender, EventArgs e)
        {
            int msg = 0;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("register_user", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", user_input.Value);
                    cmd.Parameters.AddWithValue("@UserPassword", pass_input.Value);
                    cmd.Parameters.AddWithValue("@UserCountry", country_input.Value);
                    cmd.Parameters.AddWithValue("@UserCity", city_input.Value);
                    cmd.Parameters.AddWithValue("@UserEmail", email_input.Value);
                    cmd.Parameters.Add("@msg", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    msg = (int)cmd.Parameters["@msg"].Value;
                    if (msg != -1)
                    {
                        success.Visible = true;
                        failure.Visible = false;
                    }
                    else
                    {
                        success.Visible = false;
                        failure.Visible = true;
                    }
                }
            }
        }
    }
}