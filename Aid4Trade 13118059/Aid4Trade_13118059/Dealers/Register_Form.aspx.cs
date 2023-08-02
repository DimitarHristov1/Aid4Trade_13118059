using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Dealers
{
    public partial class Register_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void reg_Click(object sender, EventArgs e)
        {
            int msg = 0;
            string dealer_type = string.Empty;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("register_dealer", con))
                {
                    if (dealer_type_dropdownlist.SelectedIndex == 0)
                    {
                        dealer_type = "Физ. лице";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealerName", dealer_input.Value);
                        cmd.Parameters.AddWithValue("@DealerPassword", pass_input.Value);
                        cmd.Parameters.AddWithValue("@DealerDescription", dealer_description_input.Value);
                        cmd.Parameters.AddWithValue("@DealerType", dealer_type);
                        cmd.Parameters.AddWithValue("@DealerCountry", country_input.Value);
                        cmd.Parameters.AddWithValue("@DealerCity", city_input.Value);
                        cmd.Parameters.AddWithValue("@Phone", dealer_phone_input.Value);
                        cmd.Parameters.AddWithValue("@DealerEmail", email_input.Value);
                        cmd.Parameters.Add("@msg", SqlDbType.Int).Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        msg = (int)cmd.Parameters["@msg"].Value;
                        if (msg != -1)
                        {
                            info.Visible = true;
                            success.Visible = true;
                            failure.Visible = false;
                        }
                        else
                        {
                            info.Visible = false;
                            success.Visible = false;
                            failure.Visible = true;
                        }
                    }
                    if (dealer_type_dropdownlist.SelectedIndex == 1)
                    {
                        dealer_type = "Юрид. лице";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealerName", dealer_input.Value);
                        cmd.Parameters.AddWithValue("@DealerPassword", pass_input.Value);
                        cmd.Parameters.AddWithValue("@DealerDescription", dealer_description_input.Value);
                        cmd.Parameters.AddWithValue("@DealerType", dealer_type);
                        cmd.Parameters.AddWithValue("@DealerCountry", country_input.Value);
                        cmd.Parameters.AddWithValue("@DealerCity", city_input.Value);
                        cmd.Parameters.AddWithValue("@Phone", dealer_phone_input.Value);
                        cmd.Parameters.AddWithValue("@DealerEmail", email_input.Value);
                        cmd.Parameters.Add("@msg", SqlDbType.Int).Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        msg = (int)cmd.Parameters["@msg"].Value;
                        if (msg != -1)
                        {
                            info.Visible = true;
                            success.Visible = true;
                            failure.Visible = false;
                        }
                        else
                        {
                            info.Visible = false;
                            success.Visible = false;
                            failure.Visible = true;
                        }
                    }
                }
            }
        }
    }
}