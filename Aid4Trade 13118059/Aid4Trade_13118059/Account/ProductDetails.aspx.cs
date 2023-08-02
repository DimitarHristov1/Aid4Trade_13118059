using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Account
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindListView();
                this.fillData();
            }
        }
        private void fillData()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from product_comment_and_user_info where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "' order by [Comment ID] desc", con);
            adapt.Fill(dt);
            con.Close();
            PagedDataSource pds = new PagedDataSource();
            DataView dv = new DataView(dt);
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.PageSize = 3;
            pds.CurrentPageIndex = PageNumber;
            if (pds.PageCount > 1)
            {
                page_numb.Visible = true;
                ArrayList arraylist = new ArrayList();
                for (int i = 0; i < pds.PageCount; i++)
                    arraylist.Add((i + 1).ToString());
                page_numb.DataSource = arraylist;
                page_numb.DataBind();
            }
            else
            {
                page_numb.Visible = false;
            }
            Comments.DataSource = pds;
            Comments.DataBind();
        }
        protected void page_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            fillData();
        }
        protected void comment_submit_Click(object sender, EventArgs e)
        {
            var register = productDetail.FindControl("register");
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        string id_cookie_user = Request.Cookies["custom_cookie"]["UserID"];
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData;
                        if (User.IsInRole("Admin"))
                        {
                            for_comments_info.Text = "Администраторите не могат да коментират продукти";
                            for_comments_info.ForeColor = System.Drawing.Color.Red;
                            for_comments_info.Visible = true;
                            return;
                        }
                        if (User.IsInRole("Dealer"))
                        {
                            for_comments_info.Text = "Търговците не могат да коментират продукти";
                            for_comments_info.ForeColor = System.Drawing.Color.Red;
                            for_comments_info.Visible = true;
                            return;
                        }
                        if (txtComment.Text == string.Empty)
                        {
                            for_comments_info.Text = "Моля напишете коментар";
                            for_comments_info.ForeColor = System.Drawing.Color.Red;
                            for_comments_info.Visible = true;
                            return;
                        }
                        SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into [Comment for product]([Product ID],[User ID],[Description of the comment]) values(@productID,@userID,@comment)", con);
                        cmd.Parameters.AddWithValue("@productID", this.Page.RouteData.Values["productID"].ToString());
                        cmd.Parameters.AddWithValue("@userID", id_cookie_user);
                        cmd.Parameters.AddWithValue("@comment", txtComment.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Коментара е публикуван.')", true);
                        fillData();
                        for_comments_info.Visible = false;
                        txtComment.Text = "";
                    }
                }
                else
                {
                    register_comment.Visible = true;
                    return;
                }
            }
        }
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                else
                    return 0;
            }
            set
            {
                ViewState["PageNumber"] = value;
            }
        }
        private void BindListView()
        {
            DataTable dt = this.GetData("SELECT [Product ID], [Dealer ID], [Product name], [Product description], [Product image], [Product price], [Dealer name], [Rating value], [Category name] FROM product_details_and_dealer_info where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "'");
            productDetail.DataSource = dt;
            productDetail.DataBind();
        }

        protected void productDetail_ItemCreated(object sender, EventArgs e)
        {
            DataTable dt = this.GetData("SELECT [Product ID], [Dealer ID], [Product name], [Product description], [Product image], [Product price], [Dealer name], [Rating value], [Category name] FROM product_details_and_dealer_info where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "'");
            Label label = (Label)productDetail.FindControl("rating");
            Label no_price = (Label)productDetail.FindControl("no_price");
            Label if_voted = (Label)productDetail.FindControl("if_voted");
            Label result_from_procedure = (Label)productDetail.FindControl("result_from_procedure");
            ImageButton thumb_up = (ImageButton)productDetail.FindControl("thumb_up");
            ImageButton thumb_down = (ImageButton)productDetail.FindControl("thumb_down");
            var price = productDetail.FindControl("price");
            var has_voted = productDetail.FindControl("has_voted");
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["Rating value"]) == 0)
                {
                    thumb_down.ImageUrl = "~/Images/thumb-down_disabled.png";
                    thumb_down.ToolTip = "Рейтинга на търговеца не може да бъде намаляван повече";
                    label.ForeColor = System.Drawing.Color.DarkRed;
                    label.Text = "Нисък рейтинг";
                    thumb_down.Enabled = false;
                }
                if (Convert.ToInt32(row["Rating value"]) == 6)
                {
                    thumb_up.ImageUrl = "~/Images/thumb-up_disabled.png";
                    thumb_up.ToolTip = "Рейтинга на търговеца не може да бъде увелечаван повече";
                    label.ForeColor = System.Drawing.Color.DarkGreen;
                    label.Text = "Висок рейтинг";
                    thumb_up.Enabled = false;
                }
                if (Convert.ToInt32(row["Rating value"]) > 0 && Convert.ToInt32(row["Rating value"]) <= 2)
                {
                    label.ForeColor = System.Drawing.Color.DarkRed;
                    label.Text = "Нисък рейтинг";
                }
                if (Convert.ToInt32(row["Rating value"]) > 2 && Convert.ToInt32(row["Rating value"]) <= 4)
                {
                    label.ForeColor = System.Drawing.Color.Orange;
                    label.Text = "Добър рейтинг";
                }
                if (Convert.ToInt32(row["Rating value"]) > 4 && Convert.ToInt32(row["Rating value"]) < 6)
                {
                    label.ForeColor = System.Drawing.Color.DarkGreen;
                    label.Text = "Висок рейтинг";
                }
            }
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        string id = Request.Cookies["custom_cookie"]["UserID"];
                        DataTable dt_id = this.GetData("SELECT [Dealer ID], [User ID], [Rating type] FROM [Dealer rating] where [User ID] = '" + id + "' and [Dealer ID] = (select [Dealer ID] from product_details_and_dealer_info where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "')");
                        foreach (DataRow row in dt_id.Rows)
                        {
                            int row_number = dt_id.Rows.Count;
                            if (row_number == 0)
                            {
                                if_voted.Visible = true;
                                if_voted.Text = "Още не сте гласували за дадения търговец";
                            }
                            if (Convert.ToString(row["Rating type"]) == "Good")
                            {
                                if (!this.IsPostBack)
                                {
                                    if_voted.Visible = true;
                                    if_voted.ForeColor = System.Drawing.Color.DarkGreen;
                                    if_voted.Text = "Гласували сте положително за дадения търговец";
                                }
                                if (this.IsPostBack)
                                {
                                    result_from_procedure.Visible = true;
                                    result_from_procedure.ForeColor = System.Drawing.Color.DarkGreen;
                                    result_from_procedure.Text = "Вие гласувахте положително за дадения търговец.";
                                }
                                thumb_up.Enabled = false;
                                thumb_down.Enabled = false;
                                thumb_up.ImageUrl = "~/Images/thumb-up_disabled.png";
                                thumb_down.ImageUrl = "~/Images/thumb-down_disabled.png";
                                thumb_up.ToolTip = "Вече сте гласували за дадения търговец";
                                thumb_down.ToolTip = "Вече сте гласували за дадения търговец";
                            }
                            if (Convert.ToString(row["Rating type"]) == "Bad")
                            {
                                if (!this.IsPostBack)
                                {
                                    if_voted.Visible = true;
                                    if_voted.ForeColor = System.Drawing.Color.DarkRed;
                                    if_voted.Text = "Гласували сте отрицателно за дадения търговец";
                                }
                                if (this.IsPostBack)
                                {
                                    result_from_procedure.Visible = true;
                                    result_from_procedure.ForeColor = System.Drawing.Color.DarkRed;
                                    result_from_procedure.Text = "Вие гласувахте отрицателно за дадения търговец.";
                                }
                                thumb_up.Enabled = false;
                                thumb_down.Enabled = false;
                                thumb_up.ImageUrl = "~/Images/thumb-up_disabled.png";
                                thumb_down.ImageUrl = "~/Images/thumb-down_disabled.png";
                                thumb_up.ToolTip = "Вече сте гласували за дадения търговец";
                                thumb_down.ToolTip = "Вече сте гласували за дадения търговец";
                            }
                        }
                    }
                }
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
        protected void thumb_up_Click(object sender, ImageClickEventArgs e)
        {
            var register = productDetail.FindControl("register");
            Label dealer_admin = (Label)productDetail.FindControl("dealer_admin");
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        string id_user_cookie = Request.Cookies["custom_cookie"]["UserID"];
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData;
                        DataTable dt = this.GetData("SELECT [Product ID], [Dealer ID], [Product name], [Product description], [Product image], [Product price], [Dealer name], [Rating value], [Category name] FROM product_details_and_dealer_info where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "'");
                        if (User.IsInRole("Dealer"))
                        {
                            dealer_admin.Visible = true;
                            dealer_admin.ForeColor = System.Drawing.Color.Red;
                            dealer_admin.Text = "Търговците не могат да гласуват.";
                            return;
                        }
                        if (User.IsInRole("Admin"))
                        {
                            dealer_admin.Visible = true;
                            dealer_admin.ForeColor = System.Drawing.Color.Red;
                            dealer_admin.Text = "Администраторите не могат да гласуват.";
                            return;
                        }
                        string ratingType = "Good";
                        int msg = 0;
                        SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("give_rating", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@UserID", id_user_cookie);
                                cmd.Parameters.AddWithValue("@ProductID", this.Page.RouteData.Values["productID"].ToString());
                                cmd.Parameters.AddWithValue("@RatingType", ratingType);
                                cmd.Parameters.Add("@msg", SqlDbType.Int).Direction = ParameterDirection.Output;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                msg = (int)cmd.Parameters["@msg"].Value;
                            }
                            if (msg == 0)
                            {
                                return;
                            }
                            if (msg == 1)
                            {
                                this.BindListView();
                            }
                        }
                    }
                }
                else
                {
                    register.Visible = true;
                    return;
                }
            }
        }
        protected void thumb_down_Click(object sender, ImageClickEventArgs e)
        {
            var register = productDetail.FindControl("register");
            Label dealer_admin = (Label)productDetail.FindControl("dealer_admin");
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        string id_user_cookie = Request.Cookies["custom_cookie"]["UserID"];
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData;
                        DataTable dt = this.GetData("SELECT [Product ID], [Dealer ID], [Product name], [Product description], [Product image], [Product price], [Dealer name], [Rating value], [Category name] FROM product_details_and_dealer_info where [Product ID] = '" + this.Page.RouteData.Values["productID"].ToString() + "'");
                        if (User.IsInRole("Dealer"))
                        {
                            dealer_admin.Visible = true;
                            dealer_admin.ForeColor = System.Drawing.Color.Red;
                            dealer_admin.Text = "Търговците не могат да гласуват.";
                            return;
                        }
                        if (User.IsInRole("Admin"))
                        {
                            dealer_admin.Visible = true;
                            dealer_admin.ForeColor = System.Drawing.Color.Red;
                            dealer_admin.Text = "Администраторите не могат да гласуват.";
                            return;
                        }
                        string ratingType = "Bad";
                        int msg = 0;
                        SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("give_rating", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@UserID", id_user_cookie);
                                cmd.Parameters.AddWithValue("@ProductID", this.Page.RouteData.Values["productID"].ToString());
                                cmd.Parameters.AddWithValue("@RatingType", ratingType);
                                cmd.Parameters.Add("@msg", SqlDbType.Int).Direction = ParameterDirection.Output;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                msg = (int)cmd.Parameters["@msg"].Value;
                            }
                            if (msg == 0)
                            {
                                return;
                            }
                            if (msg == -1)
                            {
                                this.BindListView();
                            }
                        }
                    }
                }
                else
                {
                    register.Visible = true;
                    return;
                }
            }
        }
    }
}