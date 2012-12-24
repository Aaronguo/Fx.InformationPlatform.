using System;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fx.InformationPlatform.Site.Tests.Email
{
    [TestClass]
    public class EmailTest
    {
        //http://lukencode.com/2011/04/30/fluent-email-now-supporting-razor-syntax-for-templates/
        //https://github.com/lukencode/FluentEmail
        [TestMethod]
        public void SendEmail()
        {
            var email = FluentEmail.Email
                        .From("fengxing@yingtao.co.uk")
                        .To("117822597@qq.com", "name")
                        .Subject("guzhuoyue shi zhu ")                        
                        .Body("yo dawg, sup?");
            //send normally
            email.Send();

            //send asynchronously
            email.SendAsync(SendMailCompletedEvent);
        }


        //public delegate void SendCompletedEventHandler(object sender, AsyncCompletedEventArgs e);


        public void SendMailCompletedEvent(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("ok");
        }


        [TestMethod]
        public void SendEmail2()
        {
            var template = "Dear @Model.Name, You are totally @Model.Compliment.";

            var email = FluentEmail.Email
                .From("bob@hotmail.com")
                .To("somedude@gmail.com")
                .Subject("woo nuget")
                .UsingTemplate(template, new { Name = "Luke", Compliment = "Awesome" });
            //send normally
            email.Send();

            //send asynchronously
            email.SendAsync(SendMailCompletedEvent);
        }

    }
}
