using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site
{
    public static class StaticHelper
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }

        public static string ActionName(this Controller controller)
        {
            return controller.RouteData.Route.GetRouteData(controller.HttpContext).Values["action"] as string;
        }

        public static string ControllerName(this Controller controller)
        {
            return controller.RouteData.Route.GetRouteData(controller.HttpContext).Values["controller"] as string;
        }
    }
}