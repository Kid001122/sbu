using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using VoppAPI.Classes;

public class SendEmail
{
    public static void SendMessage(string subject, string messageBody, string fromAddress, string toAddress, string ccAddress)
    {
        try
        {
           
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(toAddress, ""));
            msg.From = new MailAddress("", "");
            msg.Subject = subject;
            msg.Body = messageBody;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("", "");
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
                //lblText.Text = "Message Sent Succesfully";
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
        catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
        {
        }
    }

    public static void SendEmails(string subject, string messageBody, string fromAddress, string toAddress, string ccAddress, string strAttach, string strAtt, string strAttach2, string strAtt2, string strAttach3, string strAtt3)
    {
        MailMessage message = new MailMessage();
        SmtpClient client = new SmtpClient();
        // Dim strAtt As String
        var path = strAtt;
        var path2 = strAtt2;
        var path3 = strAtt3;

        

        try
        {
            // Set the sender's address
            message.From = new MailAddress("");

            // Allow multiple "To" addresses to be separated by a semi-colon
            if ((toAddress.Trim().Length > 0))
            {
                foreach (string addr in toAddress.Split(';'))
                    message.To.Add(new MailAddress(addr));
            }

            // Allow multiple "Cc" addresses to be separated by a semi-colon
            if ((ccAddress.Trim().Length > 0))
            {
                foreach (string addr in ccAddress.Split(';'))
                    message.CC.Add(new MailAddress(addr));
            }

            // Set the subject and message body text
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = messageBody;
            if (strAttach != "")
            {
                System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(strAttach);
                message.Attachments.Add(attach);
            }
            if (strAttach2 != "")
            {
                System.Net.Mail.Attachment attach2 = new System.Net.Mail.Attachment(path2);
                message.Attachments.Add(attach2);
            }
            if (strAttach3 != "")
            {
                System.Net.Mail.Attachment attach3 = new System.Net.Mail.Attachment(path3);
                message.Attachments.Add(attach3);
            }
            // TODO: *** Modify for your SMTP server ***
            // Set the SMTP server to be used to send the message
            client.Host = "smtp.office365.com"; //  
            client.EnableSsl = true;
            // Send the e-mail message
            client.Send(message);
        }
        catch(Exception ee)
        {
            ErrorLogger EL = new ErrorLogger();
            EL.LogError( ee,ee.ToString());
            try
            {
                MailMessage mm = new MailMessage("", toAddress);
                mm.Subject = subject;
                mm.IsBodyHtml = true;
                mm.Body = messageBody;
                if (strAttach != "")
                {
                    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(strAttach);
                    mm.Attachments.Add(attach);
                }
                if (strAttach2 != "")
                {
                    System.Net.Mail.Attachment attach2 = new System.Net.Mail.Attachment(path2);
                    mm.Attachments.Add(attach2);
                }
                if (strAttach3 != "")
                {
                    System.Net.Mail.Attachment attach3 = new System.Net.Mail.Attachment(path3);
                    mm.Attachments.Add(attach3);
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.office365.com";
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("", "", "");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credentials;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(mm);
            }

            catch (Exception ex)
            {
                ErrorLogger EL1 = new ErrorLogger();
                EL1.LogError(ex,ex.ToString());
                MailMessage mm = new MailMessage("", toAddress);
                mm.Subject = subject;
                mm.IsBodyHtml = true;
                mm.Body = messageBody;
                if (strAttach != "")
                {
                    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(strAttach);
                    mm.Attachments.Add(attach);
                }
                if (strAttach2 != "")
                {
                    System.Net.Mail.Attachment attach2 = new System.Net.Mail.Attachment(path2);
                    mm.Attachments.Add(attach2);
                }
                if (strAttach3 != "")
                {
                    System.Net.Mail.Attachment attach3 = new System.Net.Mail.Attachment(path3);
                    mm.Attachments.Add(attach3);
                }
                mm.Priority = System.Net.Mail.MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.office365.com";

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("", "");
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credentials;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}
