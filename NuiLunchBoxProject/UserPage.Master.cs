using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NuiLunchBoxProject
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] != null)
            {
                HttpCookie acookie = Request.Cookies["UserID"];
                Session["User_ID"] = acookie.Values["UserID"];
            }
            else
            {
                Session["User_ID"] = "";
            }
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }

        protected void btnContact_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnSiteMap_Click(object sender, EventArgs e)
        {

        }

        protected void Button_Modify_Click(object sender, EventArgs e)
        {

        }

        protected void btnMyAccount_Click(object sender, EventArgs e)
        {

        }
    }
}