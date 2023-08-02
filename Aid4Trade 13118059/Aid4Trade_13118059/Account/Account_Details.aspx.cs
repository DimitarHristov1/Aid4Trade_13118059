using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Account
{
    public partial class Account_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData;
                        string userName = ticket.Name;
                        string email_users = Request.Cookies["custom_cookie"]["UserEmail"];
                        string email_dealers = Request.Cookies["custom_cookie"]["DealerEmail"];
                        if (User.IsInRole("Admin"))
                        {
                            account_type_show.ForeColor = System.Drawing.Color.Red;
                            account_type_show.Text = "Администраторски акаунт";
                            accout_name_show.Text = userName;
                            if (email_users == null)
                            {
                                email_account_show.Text = email_dealers;
                            }
                            if (email_dealers == null)
                            {
                                email_account_show.Text = email_users;
                            }
                        }
                        if (User.IsInRole("User"))
                        {
                            account_type_show.ForeColor = System.Drawing.Color.Blue;
                            account_type_show.Text = "Потребителски акаунт";
                            accout_name_show.Text = userName;
                            email_account_show.Text = email_users;
                        }
                        if (User.IsInRole("Dealer"))
                        {
                            account_type_show.ForeColor = System.Drawing.Color.Green;
                            account_type_show.Text = "Търговски акаунт";
                            accout_name_show.Text = userName;
                            email_account_show.Text = email_dealers;
                        }
                    }
                }
            }
        }
    }
}