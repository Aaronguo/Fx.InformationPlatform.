using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Fx.Entity.FxBrower;
using Fx.Domain.FxBrower;
using System.Text;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class BrowerController : Controller
    {
        //
        // GET: /Brower/

        public ActionResult Index()
        {
            SaveUserAgent();

            if (CheckAgent())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect("http://oldbrower.yingtao.co.uk/");
            }
        }

        private bool CheckAgent()
        {
            var agent = Request.UserAgent;
            if (agent.Contains("MSIE 6") || agent.Contains("MSIE 7") ||
                agent.Contains("MSIE 8"))
            {
                return false;
            }
            if (agent.Contains("MSIE 9.0") || agent.Contains("MSIE 10.0"))
            {
                return true;
            }
            if (agent.Contains("Mozilla/4") || agent.Contains("Mozilla/3") ||
                agent.Contains("Mozilla/2") || agent.Contains("Mozilla/1"))
            {
                return false;
            }
            return true;

            //if (agent.Contains("Firefox/5") || agent.Contains("Firefox/6"))
            //{
            //    return true;
            //}
            //if (agent.Contains("Chrome/14") || agent.Contains("Chrome/13") ||
            //    agent.Contains("Chrome/12") || agent.Contains("Chrome/11") ||
            //    agent.Contains("Chrome/10") ||
            //    agent.Contains("Chromium/14") || agent.Contains("Chromium/13") ||
            //    agent.Contains("Chromium/12") || agent.Contains("Chromium/11") ||
            //    agent.Contains("Chromium/10"))
            //{
            //    return true;
            //}
            //if (agent.Contains("Safari"))
            //{
            //    return true;
            //}
            //if (agent.Contains("Opera"))
            //{
            //    return true;
            //}
            //return true;
        }

        private void SaveUserAgent()
        {
            BrowerService service = new BrowerService();
            if (!service.IsExist(Session.SessionID))
            {
                var agents = Request.Browser;
                var brower = new Brower();
                brower.Name = agents.Browser;
                brower.Version = agents.Version;
                brower.Platform = agents.Platform;
                brower.ECMAScriptVersion = agents.EcmaScriptVersion.ToString();
                brower.IsMobileDevice = agents.IsMobileDevice;
                brower.SessionID = Session.SessionID;
                brower.UserAgentDetails = Request.UserAgent;
                StringBuilder sb = new StringBuilder();
                foreach (System.Collections.DictionaryEntry item in agents.Capabilities)
                {
                    sb.AppendLine(item.Key + "-----" + item.Value);
                }
                brower.Other = sb.ToString();
                service.AddBrower(brower);
            }
        }

    }
}
