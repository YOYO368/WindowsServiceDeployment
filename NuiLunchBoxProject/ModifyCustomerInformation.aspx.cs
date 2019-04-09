using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NuiLunchBoxProject
{
    public partial class WebForm16 : System.Web.UI.Page
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

            dt = alayer.GetUserImformation();
            if(dt == null)
            {
                Response.Write("<script>alert('Can not get user information');window.location='ViewManagerPage.aspx';</script>");
                return;
            }
            else
            {
                CustomerInfo.DataSource = dt;
                CustomerInfo.DataBind();
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            CustomerInfo.EditIndex = e.NewEditIndex;
            this.BindListView();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string userid, passwd, name, email, mobile;
            ConnectDatabase alayer = new ConnectDatabase();
            GridViewRow row = CustomerInfo.Rows[e.RowIndex];
            userid = (CustomerInfo.Rows[e.RowIndex].FindControl("txtUserId") as TextBox).Text.Trim();
            passwd = (CustomerInfo.Rows[e.RowIndex].FindControl("txtUserPasswd") as TextBox).Text.Trim();
            name = (CustomerInfo.Rows[e.RowIndex].FindControl("txtUserName") as TextBox).Text.Trim();
            email = (CustomerInfo.Rows[e.RowIndex].FindControl("txtUserEmail") as TextBox).Text.Trim();
            mobile = (CustomerInfo.Rows[e.RowIndex].FindControl("txtUserMobile") as TextBox).Text.Trim();

            if(alayer.UpdateCustomer_Info(userid, passwd, name, email, mobile))
                lblSuccessMessage.Text = "Update Record Succeeded";
            else
                lblErrorMessage.Text = "Update Error";
            CustomerInfo.EditIndex = -1;
            this.BindListView();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            CustomerInfo.EditIndex = -1;
            this.BindListView();
        }
        protected void CustomerInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string userid, passwd, name, email, mobile;
            ConnectDatabase alayer = new ConnectDatabase();
            if (e.CommandName.Equals("UserInsert"))
            {
                userid = (CustomerInfo.FooterRow.FindControl("txtUserIdFooter") as TextBox).Text.Trim();
                passwd = (CustomerInfo.FooterRow.FindControl("txtUserPasswdFooter") as TextBox).Text.Trim();
                name = (CustomerInfo.FooterRow.FindControl("txtUserNameFooter") as TextBox).Text.Trim();
                email = (CustomerInfo.FooterRow.FindControl("txtUserEmailFooter") as TextBox).Text.Trim();
                mobile = (CustomerInfo.FooterRow.FindControl("txtUserMobileFooter") as TextBox).Text.Trim();
                if (alayer.AddNewGridView(userid, passwd, name, email, mobile))
                {
                    lblSuccessMessage.Text = "New Record Added";
                    this.BindListView();
                }
                else
                    lblErrorMessage.Text = "";
            }
        }

        protected void CustomerInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userid;
            ConnectDatabase alayer = new ConnectDatabase();
            GridViewRow row = CustomerInfo.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("txtUserId");
            userid = lbldeleteid.Text.Trim();

            if (alayer.DeleteRowGridview(userid))
                lblSuccessMessage.Text = "Delete Record Succeeded";
            else
                lblErrorMessage.Text = "Delete Error";
            this.BindListView();
        }
    }
}