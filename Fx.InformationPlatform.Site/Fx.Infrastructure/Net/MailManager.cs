using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace Fx.Infrastructure.Net
{
    //public class MailManager : IMailManager
    //{

    //    #region Private Members


    //    #endregion

    //    #region Constructors

    //    public MailManager()
    //    {
    //    }

    //    #endregion

    //    #region Public Methods

    //    public void Send(Mail mail, EmailAccount emailAccount)
    //    {
    //        Send(mail.Address,
    //            mail.DisplayName,
    //            mail.Subject,
    //            mail.BodyHTML,
    //            mail.BodyPlain,
    //            emailAccount.Address,
    //            emailAccount.DisplayName,
    //            emailAccount.Host,
    //            emailAccount.Port,
    //            emailAccount.UserName,
    //            emailAccount.Password,
    //            emailAccount.DefaultCredentials,
    //            emailAccount.Ssl);
    //    }

    //    public void Send(List<Mail> mails, EmailAccount emailAccount)
    //    {
    //        foreach (var item in mails)
    //        {
    //            Send(item.Address,
    //                item.DisplayName,
    //                item.Subject,
    //                item.BodyHTML,
    //                item.BodyPlain,
    //                emailAccount.Address,
    //                emailAccount.DisplayName,
    //                emailAccount.Host,
    //                emailAccount.Port,
    //                emailAccount.UserName,
    //                emailAccount.Password,
    //                emailAccount.DefaultCredentials,
    //                emailAccount.Ssl);
    //        }
    //    }

    //    /// <summary>
    //    /// aaa
    //    /// </summary>
    //    /// <param name="ToAddress"></param>
    //    /// <param name="ToDisplayName"></param>
    //    /// <param name="Subject"></param>
    //    /// <param name="BodyHTML"></param>
    //    /// <param name="BodyPlain"></param>
    //    /// <param name="FromAddress"></param>
    //    /// <param name="FromDisplayName"></param>
    //    /// <param name="SmtpHost"></param>
    //    /// <param name="SmtpPort"></param>
    //    /// <param name="SmtpUserName"></param>
    //    /// <param name="SmtpPassword"></param>
    //    /// <param name="SmtpDefaultCredentials"></param>
    //    /// <param name="SmtpSsl"></param>
    //    public void Send(string ToAddress, 
    //        string ToDisplayName,
    //        string Subject,
    //        string BodyHTML,
    //        string BodyPlain,
    //        string FromAddress,
    //        string FromDisplayName, 
    //        string SmtpHost,
    //        int SmtpPort,
    //        string SmtpUserName,
    //        string SmtpPassword,
    //        bool SmtpDefaultCredentials,
    //        bool SmtpSsl)
    //    {
    //        try 
    //        {
    //            MailMessage Message = new MailMessage();

    //            Message.From = new MailAddress(FromAddress, FromDisplayName);
    //            Message.To.Add(new MailAddress(ToAddress, ToDisplayName));
    //            Message.Subject = Subject;

    //            if (BodyHTML == string.Empty)
    //            {
    //                Message.Body = BodyPlain;
    //                Message.IsBodyHtml = false;
    //            }
    //            else if (BodyPlain == string.Empty)
    //            {
    //                Message.Body = BodyHTML;
    //                Message.IsBodyHtml = true;
    //            } 
    //            else 
    //            {
    //                AlternateView viewHTML = AlternateView.CreateAlternateViewFromString(BodyHTML, null, "text/html");
    //                AlternateView viewPlain = AlternateView.CreateAlternateViewFromString(BodyPlain, null, "text/plain");
    //                Message.AlternateViews.Add(viewHTML);
    //                Message.AlternateViews.Add(viewPlain);
    //            }

    //            SmtpClient client = new SmtpClient();

    //            client.Host = SmtpHost;
    //            client.Port = SmtpPort;
    //            client.EnableSsl = SmtpSsl;

    //            if (SmtpDefaultCredentials)
    //            {
    //                client.UseDefaultCredentials = true;
    //                client.DeliveryMethod = SmtpDeliveryMethod.Network;
    //            }
    //            else
    //            {
    //                client.UseDefaultCredentials = false;
    //                client.Credentials = new NetworkCredential(SmtpUserName, SmtpPassword);
    //            }

    //            try 
    //            {
    //                client.Send(Message);
    //            } 
    //            catch (Exception ex) 
    //            {
    //                Exceptions.LogException(ex);
    //            }
    //        } 
    //        catch (Exception ex) 
    //        {
    //            Exceptions.LogException(ex);
    //        }
    //    }

    //    #endregion
    //}
}