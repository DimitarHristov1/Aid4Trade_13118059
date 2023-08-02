using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Aid4Trade_13118059
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterCustomRoutes(RouteTable.Routes);
        }
        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Home",
                "Home",
                "~/Home.aspx"
            );
            routes.MapPageRoute(
                "LoginUsers",
                "LoginUsers",
                "~/Users/Login_Form.aspx"
            );
            routes.MapPageRoute(
                "RegistrationUsers",
                "RegistrationUsers",
                "~/Users/Register_Form.aspx"
            );
            routes.MapPageRoute(
                "LoginDealers",
                "LoginDealers",
                "~/Dealers/Login_Form.aspx"
            );
            routes.MapPageRoute(
                "RegistrationDealers",
                "RegistrationDealers",
                "~/Dealers/Register_Form.aspx"
            );
            routes.MapPageRoute(
                "AccountDetails",
                "AccountDetails",
                "~/Account/Account_Details.aspx"
            );
            routes.MapPageRoute(
                "CategoryByName",
                "Category/{categoryName}",
                "~/Account/ProductList.aspx"
            );
            routes.MapPageRoute(
                "ProductByName",
                "Product/{productName}={productID}",
                "~/Account/ProductDetails.aspx"
            );
            routes.MapPageRoute(
                "DealerInfo",
                "Dealer/{dealerName}={dealerID}",
                "~/Account/Dealer_Info.aspx"
            );
            routes.MapPageRoute(
                "UserInfo",
                "User/{userName}={userID}",
                "~/Account/User_Info.aspx"
            );
            routes.MapPageRoute(
                "UploadProduct",
                "UploadProduct",
                "~/Dealers/Product_Upload.aspx"
            );
            routes.MapPageRoute(
                "CreateCategory",
                "CreateCategory",
                "~/Admins/Category_Create.aspx"
            );
            routes.MapPageRoute(
                "ApproveDisapproveDealers",
                "ApproveDisapproveDealers",
                "~/Admins/Approve_Disapprove_Dealers.aspx"
            );
            routes.MapPageRoute(
                "ApproveDisapproveProducts",
                "ApproveDisapproveProducts",
                "~/Admins/Approve_Disapprove_Products.aspx"
            );
            routes.MapPageRoute(
                "ViewDealerDetails",
                "ViewDealerDetails/{dealerID}",
                "~/Admins/View_DealerDetails.aspx"
            );
            routes.MapPageRoute(
                "ViewProductDetails",
                "ViewProductDetails/{productID}",
                "~/Admins/View_ProductDetails.aspx"
            );
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
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
                        string[] roles = userData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }
    }
}