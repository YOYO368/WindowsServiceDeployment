using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NuiLunchBoxProject
{
    public partial class WebForm8 : System.Web.UI.Page
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

            dt = alayer.GetViewOrderMenuTableFromDB();
            if(dt == null)
            {
                Response.Write("<script>alert('Can not get order menu');window.location='ViewManagerPage.aspx';</script>");
                return;
            }
            else
            {
                CartView.DataSource = dt;
                CartView.DataBind();
            }
        }
    }
}