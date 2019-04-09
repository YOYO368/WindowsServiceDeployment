using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NuiLunchBoxProject
{
    public partial class WebForm5 : System.Web.UI.Page
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

            if (Request.Cookies["UserID"] == null)
            {
                Response.Write("<script>alert('You have to register or login');window.location='UserLogin.aspx';</script>");
            }
            dt = alayer.GetViewCartMenuTableFromDB();
            if (dt == null)
            {
                Response.Write("<script>alert('Can not get cart menu');window.location='ViewUserPage.aspx';</script>");
                return;
            }
            CartView.DataSource = dt;
            CartView.DataBind();
        }
        protected void itemSelected(object sender, EventArgs e)
        {
            DropDownList drop = (DropDownList)sender;
            Session["MenuTime"] = drop.SelectedItem.Text;
        }
        protected void OnOrderItem(object sender, EventArgs e)
        {
            string UserID = "",time;
            ConnectDatabase alayer = new ConnectDatabase();
            Button btn = (Button)sender;

            if(Request.Cookies["UserID"] != null)
            {
                HttpCookie acookie = Request.Cookies["UserID"];
                UserID = acookie.Values["UserID"];
            }
            if (Session["MenuTime"] != null)
            {
                time = Session["MenuTime"].ToString();
            }
            else
            {
                time = "07:00 - 08:00";
            }
            if (!alayer.CheckOrderMenuImage(btn.CommandName))
            {
                if (alayer.SaveCartMenuToOrder(UserID, btn.CommandName, btn.CommandArgument, time))
                {
                    if (alayer.CheckCartMenuImage(btn.CommandName))
                    {
                        alayer.DeleteCartMenu(btn.CommandName);
                    }
                    Response.Write("<script>alert('Selected menu is ordered');</script>");
                    BindListView();
                }
                else
                    Response.Write("<script>alert('Selected menu is not ordered **********');</script>");
            }
            else
            {
                Response.Write("<script>alert('Same menu already exist');</script>");
                return;
            }
        }
        protected void OnDeleteItem(object sender, EventArgs e)
        {
            ConnectDatabase alayer = new ConnectDatabase();
            Button btn = (Button)sender;
            if (alayer.CheckCartMenuImage(btn.CommandName))
            {
                alayer.DeleteCartMenu(btn.CommandName);
                Response.Write("<script>alert('Selected menu is deleted');</script>");
                BindListView();
            }
            else
            {
                Response.Write("<script>alert('Can not delete this menu');</script>");
            }
        }
    }
 }