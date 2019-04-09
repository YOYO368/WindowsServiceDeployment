using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NuiLunchBoxProject
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("CheckCount");
            Session.Remove("ClickName");
            Session.Remove("ClickGroup");
            Response.Write("<script>alert('Manager logout success !!!');window.location = 'ViewUserPage.aspx';</script>");
        }
    }
}