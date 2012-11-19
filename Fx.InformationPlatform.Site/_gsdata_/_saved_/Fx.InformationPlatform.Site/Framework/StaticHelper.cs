using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site
{
    public static class Helper
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



        public static string GetTimeStamp(this DateTime t)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string GetDate()
        {
            return string.Format("{0:yyyyMMdd}", DateTime.Now);
        }
    }
}