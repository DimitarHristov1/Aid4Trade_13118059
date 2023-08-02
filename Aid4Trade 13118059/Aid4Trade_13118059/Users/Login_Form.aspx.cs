using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Users
{
    public partial class Login_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_Click(object sender, EventArgs e)
        {
            int userId = 0;
            string role = string.Empty;
            string userName = string.Empty;
            string userEmail = string.Empty;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("validate_user"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserEmail", email_input.Value);
                    cmd.Parameters.AddWithValue("@Password", pass_input.Value);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    userId = Convert.ToInt32(reader["UserId"]);
                    role = reader["Role"].ToString();
                    userName = reader["User name"].ToString();
                    userEmail = reader["User email"].ToString();
                    con.Close();
                }
                switch (userId)
                {
                    case -1:
                        failure.Visible = true;
                        break;
                    default:
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(2880), checkbox.Checked, role, FormsAuthentication.FormsCookiePath);
                        string hash = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                        HttpCookie custom_cookie = new HttpCookie("custom_cookie", hash);
                        custom_cookie.Values.Add("UserID", userId.ToString());
                        custom_cookie.Values.Add("UserEmail", userEmail.ToString());
                        if (ticket.IsPersistent)
                        {
                            cookie.Expires = ticket.Expiration;
                            custom_cookie.Expires = ticket.Expiration;
                        }
                        Response.Cookies.Add(cookie);
                        Response.Cookies.Add(custom_cookie);
                        Response.Redirect(GetRouteUrl("Home",null));
                        break;
                }
            }
        }
    }
}