using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NuiLunchBoxProject
{
    public partial class WebForm15 : System.Web.UI.Page
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
            string GroupNo;
            int num = 0;

            if (Request.QueryString["Menu_Group"] != null)
            {
                GroupNo = Request.QueryString["Menu_Group"];
                Session["ClickGroup"] = GroupNo;
                if (GroupNo != null && !GroupNo.Equals(""))
                    num = Convert.ToInt32(GroupNo);
            }
            dt = alayer.GetViewMenuTableFromDB(num);
            if(dt != null)
            {
                MenuList.DataSource = dt;
                MenuList.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Can not use database table');window.location='ViewUserPage.aspx';</script>");
            }
        }
    }
}