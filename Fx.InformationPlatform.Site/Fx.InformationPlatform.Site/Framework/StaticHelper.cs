using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Fx.Domain.Account.IService;

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

        /// <summary>
        /// 获取枚举类子项描述信息
        /// </summary>
        /// <param name="enumSubitem">枚举类子项</param>        
        public static string GetEnumDescription(this Enum enumSubitem)
        {
            string strValue = enumSubitem.ToString();
            System.Reflection.FieldInfo fieldinfo = enumSubitem.GetType().GetField(strValue);
            if (fieldinfo != null)
            {
                Object[] objs = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs == null || objs.Length == 0)
                {
                    return strValue;
                }
                else
                {
                    DescriptionAttribute da = (DescriptionAttribute)objs[0];
                    return da.Description;
                }
            }
            else
            {
                return "UnKonw";
            }
        }


        public static object GetSessionName(this HttpSessionState session,string key)
        {
            if (session[key]==null || string.IsNullOrWhiteSpace(session[key].ToString()))
            {
                IAccountService  account=System.Web.Mvc.DependencyResolver.Current.GetService<IAccountService>();
                var userExtend = account.GetUserExtendInfo(key);
                session[key] = userExtend.NickName == null ? "" : userExtend.NickName;
            }
            return session[key];
        }
    }
}