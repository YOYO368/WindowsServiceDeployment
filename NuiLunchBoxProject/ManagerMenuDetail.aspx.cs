using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace NuiLunchBoxProject
{
    public partial class WebForm10 : System.Web.UI.Page
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
            SqlDataReader reader;
            int num = 0;
            string GroupNo, MenuName = "", ImagePath, MenuPrice, MenuDescription;

            if (Request.QueryString["Menu_Name"] != null)
                MenuName = Request.QueryString["Menu_Name"];
            if (Request.QueryString["Menu_Group"] != null)
            {
                GroupNo = Request.QueryString["Menu_Group"];
                Label_Groupno.Text = GroupNo;
                if (GroupNo != "" && GroupNo != null)
                    num = Convert.ToInt32(GroupNo.ToString());
            }
            reader = alayer.GetAllMenuTableFromDB(num, MenuName);
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
                        ImageUpload.SaveAs(ImagePath);
                        txtMenuDescription.Text = MenuDescription;
                    }
                    reader.NextResult();
                }
            }
            else
            {
                Response.Write("<script>alert('Can not get data from database');</script>");
            }
            reader.Close();
        }
        protected void btnModify_Click(object sender, EventArgs e)
        {
            ImageUpload.Visible = true;
            txtMenuName.Enabled = true;
            txtMenuPrice.Enabled = true;
            txtMenuDescription.Enabled = true;
            btnModify.Visible = false;
            btnSave.Visible = true;
            btnDelete.Visible = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ConnectDatabase alayer = new ConnectDatabase();
            btnModify.Visible = true;
            btnSave.Visible = false;
            int groupnom = 0;

            if (txtMenuName.Text == "")
            {
                Response.Write("<script>alert('You have to input filename');</script>");
                return;
            }
            else if(txtMenuPrice.Text == "")
            { 
                Response.Write("<script>alert('You have to input menu price');</script>");
                return;
            }
            else if(ImageUpload.PostedFile.FileName == "")
            {
                Response.Write("<script>alert('You have to input menu image');</script>");
                return;
            }
            else if (txtMenuDescription.Text == "")
            {
                Response.Write("<script>alert('You have to input menu description');</script>");
                return;
            }
            else
            {
                if(Label_Groupno.Text != "" && Label_Groupno.Text != null)
                    groupnom = Convert.ToInt32(Label_Groupno.Text); 
                if(alayer.ModifyMenuInformation(groupnom,txtMenuName.Text,txtMenuPrice.Text, ImageUpload.PostedFile.FileName,txtMenuDescription.Text))
                    Response.Write("<script>alert('Menu information is changed');</script>");
                else
                    Response.Write("<script>alert('Menu information is not changed');</script>");
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int groupnom = 0;
            ConnectDatabase alayer = new ConnectDatabase();
            if (txtMenuName.Text == "")
            {
                Response.Write("<script>alert('You have to input filename');</script>");
                return;
            }
            else
            {
                if (Label_Groupno.Text != "" && Label_Groupno.Text != null)
                    groupnom = Convert.ToInt32(Label_Groupno.Text);
                if(alayer.DeleteOneItemFromTable(groupnom,txtMenuName.Text))
                    Response.Write("<script>alert('Delete success');</script>");
                else
                    Response.Write("<script>alert('Delete failed');</script>");
            }
        }
    }
}