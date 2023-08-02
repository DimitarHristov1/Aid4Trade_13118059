using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Dealers
{
    public partial class Login_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_Click(object sender, EventArgs e)
        {
            int dealerId = 0;
            string role = string.Empty;
            string dealerStatus = string.Empty;
            string dealerName = string.Empty;
            string dealerEmail = string.Empty;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("validate_dealer"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DealerEmail", email_input.Value);
                    cmd.Parameters.AddWithValue("@Password", pass_input.Value);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    dealerId = Convert.ToInt32(reader["Dealer ID"]);
                    role = reader["Role"].ToString();
                    dealerStatus = reader["Dealer status"].ToString();
                    dealerName = reader["Dealer name"].ToString();
                    dealerEmail = reader["Dealer email"].ToString();
                    con.Close();
                }
                switch (dealerId)
                {
                    case -1:
                        failure.ForeColor = System.Drawing.Color.Red;
                        failure.Text = "Грешен имейл адрес или парола!";
                        failure.Visible = true;
                        break;
                    default:
                        if (dealerStatus == "Not Approved")
                        {
                            failure.Text = "Вие не сте одобрен!";
                            failure.ForeColor = System.Drawing.Color.Red;
                            failure.Visible = true;
                        }
                        if (dealerStatus == "Registered")
                        {
                            failure.Text = "Още не сте одобрен";
                            failure.ForeColor = System.Drawing.Color.Blue;
                            failure.Visible = true;
                        }
                        if (dealerStatus == "Approved")
                        {
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, dealerName, DateTime.Now, DateTime.Now.AddMinutes(2880), checkbox.Checked, role, FormsAuthentication.FormsCookiePath);
                            string hash = FormsAuthentication.Encrypt(ticket);
                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                            HttpCookie custom_cookie = new HttpCookie("custom_cookie", hash);
                            custom_cookie.Values.Add("DealerID", dealerId.ToString());
                            custom_cookie.Values.Add("DealerEmail", dealerEmail.ToString());
                            if (ticket.IsPersistent)
                            {
                                cookie.Expires = ticket.Expiration;
                                custom_cookie.Expires = ticket.Expiration;
                            }
                            Response.Cookies.Add(cookie);
                            Response.Cookies.Add(custom_cookie);
                            Response.Redirect(GetRouteUrl("Home", null));
                        }
                        break;
                }
            }
        }
    }
}