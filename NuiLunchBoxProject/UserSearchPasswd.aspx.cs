using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace NuiLunchBoxProject
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                txtEmail.Focus();
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            MailMessage message = new System.Net.Mail.MailMessage();

            message.From = new MailAddress(txtEmail.Text);
            message.To.Add(new MailAddress("youngeunmia@gmail.com"));
            message.Subject = "Hi! This mail is about password";
            message.Body = "Return address : " + txtEmail.Text;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("youngeunmia@gmail.com", "vxxmrxohomxdzwoj");
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something problem');window.location='UserLogin.aspx';</script>");
            }
            Response.Write("<script>alert('Sending E-mail success');window.location='UserLogin.aspx';</script>");
        }
    }
}