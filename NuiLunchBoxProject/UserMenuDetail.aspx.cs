using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NuiLunchBoxProject
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectDatabase alayer = new ConnectDatabase();
            SqlDataReader reader;
            int num = 0;
            string GroupNo, MenuName="", ImagePath, MenuPrice, MenuDescription, Mode;

            if (Request.QueryString["Menu_Name"] != null)
                MenuName = Request.QueryString["Menu_Name"];
            if (Request.QueryString["Menu_Group"] != null)
            {
                GroupNo = Request.QueryString["Menu_Group"];
                Label_Groupno.Text = GroupNo;
                if (GroupNo != null && !GroupNo.Equals(""))
                    num = Convert.ToInt32(GroupNo);
            }
            reader = alayer.GetAllMenuTableFromDB(num,MenuName);
            if (reader != null)
            {
                while (reader.HasRows)
                {
                    MenuName = reader.GetName(0);
                    MenuPrice = reader.GetName(1);

                    while (reader.Read())
                    {
                        MenuName = reader.GetString(0);
                        MenuPrice = reader.GetString(1);
                        ImagePath = reader.GetString(2);
                        MenuDescription = reader.GetString(3);

                        ImagePath = ImagePath.Trim();
                        MenuDescription = MenuDescription.Trim();

                        Label3.Text = MenuName;
                        Image1.ImageUrl = ImagePath;
                        txtMenuName.Text = MenuName;
                        txtMenuPrice.Text = MenuPrice;
                        Session["ImagePath"] = ImagePath;
                        txtMenuDescription.Text = MenuDescription;
                    }
                    reader.NextResult();
                }
            }
            else
            {
                Response.Write("<script>alert('Can not get data from database');window.location='ViewUserPage.aspx';</script>");
                return;
            }
            reader.Close();
        }
        protected void btnGoCart_Click(object sender, EventArgs e)
        {
            ConnectDatabase alayer = new ConnectDatabase();

            int num = 0;
            if (Request.Cookies["UserID"] == null)
            {
                Response.Write("<script>alert('You have to register or login');window.location='UserLogin.aspx';</script>");
                return;
            }
            if (txtCount.Text != null && !txtCount.Text.Equals(""))
                num = Convert.ToInt32(txtCount.Text.ToString());
            if (num == 0)
            {
                Response.Write("<script>alert('Do not choose menu. Please choosing menu count');</script>");
                return;
            }
            else
            {
                if(alayer.CheckCartMenuImage(txtMenuName.Text))
                {
                    Response.Write("<script>alert('There are same menu in the cart');window.location='ViewCart.aspx';</script>");
                }
                else
                {
                    alayer.SaveCartMenu(Label_Groupno.Text, txtMenuName.Text, Session["ImagePath"].ToString(), txtCount.Text, txtMenuPrice.Text);
                    Response.Write("<script>alert('This menu save the cart');window.location='ViewCart.aspx';</script>");
                    Session["ImagePath"] = "";
                }              
            }
        }
         protected void btnIncrease_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (txtCount.Text != null && !txtCount.Text.Equals(""))
                num = Convert.ToInt32(txtCount.Text);
            num++;
            txtCount.Text = Convert.ToString(num);
        }

        protected void btnDecrease_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (txtCount.Text != null && !txtCount.Text.Equals(""))
                num = Convert.ToInt32(txtCount.Text);
            if (num > 0)
                num--;
            txtCount.Text = Convert.ToString(num);
        }
    }
}