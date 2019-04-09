using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NuiLunchBoxProject
{
    public partial class WebForm13 : System.Web.UI.Page
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
            SqlDataReader reader;
            string UserID, UserPasswd, UserName, UserEmail, UserMobile;
            ConnectDatabase alayer = new ConnectDatabase();

            if (Request.Cookies["UserID"] == null)
            {
                Response.Write("<script>alert('You have to resister or login');window.location='UserLogin.aspx';</script>");
            }
            else
            {
                HttpCookie acookie = Request.Cookies["UserID"];
                String temp = acookie.Values["UserID"];
                reader = alayer.GetUserImformation(temp);
                if (reader != null)
                {
                    while (reader.HasRows)
                    {
                        UserID = reader.GetName(0);
                        UserPasswd = reader.GetName(1);
                        while (reader.Read())
                        {
                            UserID = reader.GetString(0);
                            UserPasswd = reader.GetString(1);
                            UserName = reader.GetString(2);
                            UserEmail = reader.GetString(3);
                            UserMobile = reader.GetString(4);

                            if (txtUserID.Text == "")
                                txtUserID.Text = UserID;
                            if (txtUserPasswd.Text == "")
                            {
                                txtUserPasswd.Text = "********";
                                Session["UserPasswd"] = UserPasswd;
                                txtUserPasswd.Focus();
                            }
                            if (txtUserName.Text == "")
                                txtUserName.Text = UserName;
                            if (txtUserEmail.Text == "")
                                txtUserEmail.Text = UserEmail;
                            if (txtUserMobile.Text == "")
                                txtUserMobile.Text = UserMobile;
                        }
                        reader.NextResult();
                    }
                }
            }
        }
        protected void Button_Modify_Click(object sender, EventArgs e)
        {
            txtUserID.ReadOnly = false;
            txtUserPasswd.Enabled = true;
            txtConfirmPasswd.Enabled = true;
            txtUserName.Enabled = true;
            txtUserEmail.Enabled = true;
            txtUserMobile.Enabled = true;
            Button_Save.Visible = true;
            Button_Modify.Visible = false;
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            ConnectDatabase alayer = new ConnectDatabase();
            string passwd;

            if (txtUserPasswd.Text != "")
                passwd = txtUserPasswd.Text;
            else
                passwd = Session["UserPasswd"].ToString();
            alayer.ModifyUserInformation(txtUserID.Text, passwd, txtUserName.Text, txtUserEmail.Text, txtUserMobile.Text);
            Response.Write("<script>alert('User information modify success');</script>");
            BindListView();
        }

        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            txtUserPasswd.Text = "";
            txtConfirmPasswd.Text = "";
            txtUserName.Text = "";
            txtUserEmail.Text = "";
            txtUserMobile.Text = "";
        }
    }
}