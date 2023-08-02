using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aid4Trade_13118059.Dealers
{
    public partial class Product_Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Admin") || User.IsInRole("User"))
            {
                Response.Redirect(GetRouteUrl("Home", null));
            }
            if (!IsPostBack)
            {
                bindData();
            }
        }
        protected void bindData()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
            con.Open();
            string query = "SELECT [Category ID], [Category name] FROM Categories";
            SqlCommand command = new SqlCommand(query, con);
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            product_category_dropdownlist.DataSource = table;
            product_category_dropdownlist.DataValueField = "Category ID";
            product_category_dropdownlist.DataTextField = "Category name";
            product_category_dropdownlist.DataBind();

        }
        protected void Upload_Click(object sender, EventArgs e)
        {
            string[] validFileTypes = { "png", "jpg", "jpeg" };
            string ext = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);
            bool isValidFile = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                result.ForeColor = System.Drawing.Color.Red;
                result.Text = "Невалиден формат на файла. Моля качвайте само файлове със формати: " + string.Join(",", validFileTypes);
            }
            else
            {
                string fileName = Path.GetFileName(FileUpload.PostedFile.FileName);
                string dealerID = Request.Cookies["custom_cookie"]["DealerID"];
                SqlConnection con = new SqlConnection(Properties.Settings.Default.constring);
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("upload_product", con))
                    {
                        if (product_price_input.Value == string.Empty)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@DealerID", dealerID);
                            cmd.Parameters.AddWithValue("@ProductName", product_name_input.Value);
                            cmd.Parameters.AddWithValue("@ProductDescription", product_description_input.Value);
                            cmd.Parameters.AddWithValue("@ProductImage", fileName);
                            cmd.Parameters.AddWithValue("@ProductPrice", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CategoryID", product_category_dropdownlist.SelectedValue);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            FileUpload.PostedFile.SaveAs(Server.MapPath("~/Images/Products/") + fileName);
                            result.ForeColor = System.Drawing.Color.Green;
                            result.Text = "Продуктът е успешно качен в системата.";
                            to_result.Visible = true;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@DealerID", dealerID);
                            cmd.Parameters.AddWithValue("@ProductName", product_name_input.Value);
                            cmd.Parameters.AddWithValue("@ProductDescription", product_description_input.Value);
                            cmd.Parameters.AddWithValue("@ProductImage", fileName);
                            cmd.Parameters.AddWithValue("@ProductPrice", product_price_input.Value.Replace(",","."));
                            cmd.Parameters.AddWithValue("@CategoryID", product_category_dropdownlist.SelectedValue);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            FileUpload.PostedFile.SaveAs(Server.MapPath("~/Images/Products/") + fileName);
                            result.ForeColor = System.Drawing.Color.Green;
                            result.Text = "Продуктът е успешно качен в системата.";
                            to_result.Visible = true;
                        }
                    }
                }
            }
        }
    }
}