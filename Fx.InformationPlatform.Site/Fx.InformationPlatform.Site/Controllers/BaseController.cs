using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class BaseController : Controller
    {
        protected string ControllerName { get; private set; }
        protected string ActionName { get; private set; }
        protected string RoutePars { get; private set; }


        public virtual void InitParas()
        {
            ActionName = this.ActionName();
            ControllerName = this.ControllerName();
        }
    }
}
