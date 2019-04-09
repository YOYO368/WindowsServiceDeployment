using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NuiLunchBoxProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                txtUserID.Focus();
        }

        protected void Button_Register_Click(object sender, EventArgs e)
        {
            ConnectDatabase aLayer = new ConnectDatabase();
            if (aLayer.CheckUserID(txtUserID.Text))
            {
                Response.Write("<script>alert('Same UserID aleady exit!!');</script>");
            }
            else
            {
                if (aLayer.SaveUserInformation(txtUserID.Text, txtUserPasswd.Text, txtUserName.Text, txtUserEmail.Text, txtUserMobile.Text))
                { 
                    Response.Write("<script>alert('Register Success ^^');window.location = 'UserLogin.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('Can not use database table');window.location = 'ViewUserPage.aspx';</script>");
                    return;
                }
            }
        }

        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtUserPasswd.Text = "";
            txtConfirmPasswd.Text = "";
            txtUserName.Text = "";
            txtUserEmail.Text = "";
            txtUserMobile.Text = "";
        }
    }
}