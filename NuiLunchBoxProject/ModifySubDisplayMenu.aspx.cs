using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Data;
using System.Configuration;

namespace NuiLunchBoxProject
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindListView();
                txtMenuName.Focus();
                this.Page.Form.Enctype = "multipart/form-data";
            }
        }
        public void BindListView()
        {
            ConnectDatabase alayer = new ConnectDatabase();
            DataTable dt;
            string GroupNo = "";
            int num = 0;

            if (Request.QueryString["Menu_Group"] != null)
            {
                GroupNo = Request.QueryString["Menu_Group"];
                Session["ClickGroup"] = GroupNo;
                if (GroupNo != null && !GroupNo.Equals(""))
                    num = Convert.ToInt32(GroupNo);
            }
            if(GroupNo != "")
                txtMenuGroup.Text = GroupNo;
            switch (num)
            {
                case 1:
                    GroupNo = "Salad table";
                    break;
                case 2:
                    GroupNo = "RiceRoll table";
                    break;
                case 3:
                    GroupNo = "FullPackage table";
                    break;
                case 4:
                    GroupNo = "Rice table";
                    break;
                case 5:
                    GroupNo = "SideDish table";
                    break;
                case 6:
                    GroupNo = "Sandwich table";
                    break;
            }
            btnAddMenu.Text = "Add to " + GroupNo;
            dt = alayer.GetViewMenuTableFromDB(num);
            if(dt != null)
            {
                MenuList.DataSource = dt;
                MenuList.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Can not use database table');window.location='ViewManagerPage.aspx';</script>");
                return;
            }
        }

        protected void btnAddData_Click(object sender, EventArgs e)
        {
            int count = 0, gnum = 0;
            string path;
            ConnectDatabase alayer = new ConnectDatabase();

            CheckControlEmpty();

            if (Session["ClickGroup"] != null)
                    gnum = Convert.ToInt32(Session["ClickGroup"]);
            count = alayer.GetDisplayItemCount();
            path = CopyFile();
            if (path != "")
            {
                if (alayer.CheckSubDisplayMenuImage(gnum, txtMenuName.Text, path))
                {
                    Response.Write("<script>alert('Same menu has aready existed');</script>");
                }
                else
                {
                    if (Radio_Yes.Checked)
                    {
                        if (alayer.CheckMainDisplayMenuImage(txtMenuName.Text, path))
                        {
                            Response.Write("<script>alert('Same menu has aready existed');</script>");
                        }
                        else
                        {
                            if (count > 7)
                            {
                                Response.Write("<script>alert('Can not add image anymore. Just insert into the sub menu');</script>");
                            }
                            else
                            {
                                alayer.SaveMainDisplayMenu(Session["ClickGroup"].ToString(), txtMenuName.Text, path);
                            }
                        }
                    }
                    alayer.SaveSubDisplayMenu(Session["ClickGroup"].ToString(), txtMenuName.Text, txtMenuPrice.Text, path, txtDescription.Text);
                    Response.Write("<script>alert('Adding menu success!!!');</script>");
                    BindListView();
                }
                ClearViewAddMenu();
            }
            else
            {
                Response.Write("<script>alert('You have to choose file again');</script>");
                return;
            }
        }
        public void CheckControlEmpty()
        {
            if (txtMenuName.Text == "")
            {
                Response.Write("<script>alert('You have to input filename');</script>");
                return;
            }
            else if (txtMenuPrice.Text == "")
            {
                Response.Write("<script>alert('You have to input filename');</script>");
                return;
            }
            else if (txtDescription.Text == "")
            {
                Response.Write("<script>alert('You have to input filename');</script>");
                return;
            }
        }
        public void ClearViewAddMenu()
        {
            txtMenuName.Text = "";
            txtMenuPrice.Text = "";
            txtDescription.Text = "";
            Session["ImagePath"] = "";
            Radio_No.Checked = true;
        }
        public string CopyFile()
        {
            int gnum = 0;
            string folderPath = Server.MapPath("~/Files/");
            string path,display = "";

            if (ImageUpload.PostedFile.FileName != "")
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                if (Session["ClickGroup"] != null)
                    gnum = Convert.ToInt32(Session["ClickGroup"]);
                switch (gnum)
                {
                    case 1:
                        path = folderPath + "Salad/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        display = "./Files/Salad/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        break;
                    case 2:
                        path = folderPath + "RiceRoll/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        display = "./Files/RiceRoll/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        break;
                    case 3:
                        path = folderPath + "KoreanFullPackage/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        display = "./Files/KoreanFullPackage/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        break;
                    case 4:
                        path = folderPath + "Korean-Rice/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        display = "./Files/Korean-Rice/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        break;
                    case 5:
                        path = folderPath + "Korean-SideDish/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        display = "./Files/Korean-SideDish/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        break;
                    case 6:
                        path = folderPath + "Sandwich/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        display = "./Files/Sandwich/" + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        break;
                    default:
                        path = folderPath + Path.GetFileName(ImageUpload.PostedFile.FileName);
                        display = "";
                        break;
                }
                ImageUpload.SaveAs(path);
            }
            return display;
        }
    }
}