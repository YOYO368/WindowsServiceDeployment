using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace NuiLunchBoxProject
{
    public partial class ViewMasterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindListView();
            }
        }

        public void BindListView()
        {
            ConnectDatabase alayer = new ConnectDatabase();
            DataTable dt;

            if (Request.Cookies["UserID"] != null)
            {
                HttpCookie acookie = Request.Cookies["UserID"];
                Session["User_ID"] = acookie.Values["UserID"];
            }
            dt = alayer.GetViewDisplayMenuTableFromDB();
            if(dt == null)
            {
                Response.Write("<script>alert('Can not use database table');</script>");
                return;
            }
            else
            {
                if (dt.DefaultView.Count == 0)
                {
                    dt = alayer.GetViewNoImageMenuTableFromDB();
                }
                MenuList.DataSource = dt;
                MenuList.DataBind();
            }           
        }
    }
}