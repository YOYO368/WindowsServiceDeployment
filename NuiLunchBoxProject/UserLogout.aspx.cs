using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NuiLunchBoxProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie acookie = new HttpCookie("UserID");

            acookie.Expires = DateTime.Now.AddDays(-3);
            Response.Cookies.Add(acookie);
            Session.Remove("User_ID");
            Response.Write("<script>alert('Your logout success');window.location = 'ViewUserPage.aspx';</script>");
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
        }
    }
}