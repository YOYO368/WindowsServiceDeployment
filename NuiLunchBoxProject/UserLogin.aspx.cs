using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NuiLunchBoxProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                 txtUserID.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ConnectDatabase aLayer = new ConnectDatabase();
            if (aLayer.CheckUserID(txtUserID.Text))
            {
                if(aLayer.CheckUser_Passwd(txtUserPasswd.Text))
                {
                    if(txtUserID.Text == "Admin")
                    {
                        if(txtUserPasswd.Text == "Admin")
                        {
                            Response.Write("<script>alert('Move to Manager Page');window.location = 'ViewManagerPage.aspx';</script>");
                        }
                    }
                    else
                    {
                        HttpCookie acookie = new HttpCookie("UserID");
                        acookie.Values["UserID"] = txtUserID.Text;
                        acookie.Expires.AddDays(30);
                        Session["User_ID"] = txtUserID.Text;
                        Response.Cookies.Add(acookie);
                        Response.Write("<script>alert('Your login success');window.location = 'ViewUserPage.aspx';</script>");
                    }
                }
                else
                {
                    ClearTextBox();
                    Response.Write("<script>alert('Can not find password');</script>");
                }
            }
            else
            {
                ClearTextBox();
                Response.Write("<script>alert('Can not find User ID');</script>");
            }
        }
        void ClearTextBox()
        {
            txtUserID.Text = "";
            txtUserPasswd.Text = "";
        }

        protected void Menu_Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRegister.aspx");
        }
    }
}