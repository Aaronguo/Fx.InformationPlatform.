using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class BaseController : Controller
    {
        protected Ninject.IKernel Kernel;

        public BaseController()
        {
           
        }

    }
}
