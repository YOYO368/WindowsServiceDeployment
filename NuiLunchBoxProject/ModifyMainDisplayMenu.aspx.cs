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
    public partial class WebForm6 : System.Web.UI.Page
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

            dt = alayer.GetViewDisplayMenuTableFromDB();
            if (dt == null)
            {
                Response.Write("<script>alert('Can not use database table');</script>");
                return;
            }
            else
            {
                dt = alayer.GetViewDisplayMenuTableFromDB();
                MenuList.DataSource = dt;
                MenuList.DataBind();
            }
        }
        public void SaveSelectedMainDisplayMenu(string num, string name)
        {
            ConnectDatabase alayer = new ConnectDatabase();
            int checkcount = 0;
            if(Session["CheckCount"] != null && !Session["CheckCount"].ToString().Equals(""))
                checkcount = Convert.ToInt32(Session["CheckCount"]);

            if (name != null && num != null)
            {
                alayer.SaveSelectedMainDisplayMenu(num, name);
                checkcount++;
                Label2.Text = Convert.ToString(checkcount);
                Session["CheckCount"] = Convert.ToString(checkcount);
            }
        }
        public void DecreaseCheckCount(string name)
        {
            ConnectDatabase alayer = new ConnectDatabase();
            int i = 0;

            if(Session["CheckCount"] != null && !Session["CheckCount"].ToString().Equals(""))
                i = Convert.ToInt32(Session["CheckCount"]);
            if(i > 0)
            { 
                i--;
                Session["CheckCount"] = Convert.ToString(i);
                alayer.DeleteSelectedMainDisplayMenu(name);
                Label2.Text = Convert.ToString(i);
            }
            else
            {
                Session["CheckCount"] = "0";
            }
        }
        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox bCheck = (CheckBox)sender;
            if (bCheck.Checked == true)
                SaveSelectedMainDisplayMenu(bCheck.ClientID, bCheck.Text);
            else
                DecreaseCheckCount(bCheck.Text);
        }
        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            ConnectDatabase alayer = new ConnectDatabase();
            SqlDataReader reader;
            string MenuName, GroupNo;
            int groupno = 0;

            reader = alayer.GetSelectMenu();
            if (reader != null)
            {
                while (reader.HasRows)
                {
                    MenuName = reader.GetName(0);
                    GroupNo = reader.GetName(1);
                    while (reader.Read())
                    {
                        MenuName = reader.GetString(0);
                        GroupNo = reader.GetString(1);
                        MenuName = MenuName.Trim();
                        GroupNo = GroupNo.Trim();
                        if (GroupNo != null && !GroupNo.Equals(""))
                            groupno = Convert.ToInt32(GroupNo);
                        if (MenuName != "")
                        {
                            alayer.DeleteMainDisplayMenu(groupno, MenuName);
                        }
                    }
                    reader.NextResult();
                }
            }
            if(Session["CheckCount"] != null)
            {
                Response.Write("<script> alert('All checked items are deleted');</script>");
                Session["CheckCount"] = "0";
                Label2.Text = Session["CheckCount"].ToString();
                this.BindListView();
            }
        }
    }
}