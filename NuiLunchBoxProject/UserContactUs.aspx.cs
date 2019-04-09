using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace NuiLunchBoxProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            MailMessage message = new System.Net.Mail.MailMessage();

            message.From = new MailAddress(txtUserEmail.Text);
            message.To.Add(new MailAddress("youngeunmia@gmail.com"));
            message.Subject = txtUserSubject.Text;
            message.Body = txtMessage.Text;

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
                Response.Write("<script>alert('Something problem');</script>");
                txtUserEmail.Text = "";
                txtMessage.Text = "";
                txtUserName.Text = "";
                txtUserSubject.Text = "";
            }
            Response.Write("<script>alert('Sending E-mail success');</script>");
        }
    }
}