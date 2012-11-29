using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Infrastructure.Caching;
using SimpleInjector;

namespace Fx.InformationPlatform.Site
{
    public class AppSettings
    {
        static ICacheManager cacheService;

        static AppSettings()
        {
            cacheService = DependencyResolver.Current.GetService<ICacheManager>();
        }
        #region Private Methods

        private static string GetValue(string Key)
        {
            string Value = ConfigurationManager.AppSettings[Key];
            if (!string.IsNullOrEmpty(Value))
            {
                return Value;
            }
            return string.Empty;
        }

        private static string GetString(string Key, string DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                return Setting;
            }
            return DefaultValue;
        }

        private static bool GetBool(string Key, bool DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                switch (Setting.ToLower())
                {
                    case "false":
                    case "0":
                    case "n":
                        return false;
                    case "true":
                    case "1":
                    case "y":
                        return true;
                }
            }
            return DefaultValue;
        }

        private static int GetInt(string Key, int DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                int i;
                if (int.TryParse(Setting, out i))
                {
                    return i;
                }
            }
            return DefaultValue;
        }

        private static double GetDouble(string Key, double DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                double d;
                if (double.TryParse(Setting, out d))
                {
                    return d;
                }
            }
            return DefaultValue;
        }

        private static byte GetByte(string Key, byte DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                byte b;
                if (byte.TryParse(Setting, out b))
                {
                    return b;
                }
            }
            return DefaultValue;
        }

        #endregion

        #region Public Properties

        public static string SiteName
        {
            get { return GetString("SiteName", "英淘网"); }
        }

        public static string DefaultLanguage
        {
            get { return GetString("DefaultLanguage", "zh-CN"); }  //en-US
        }


        public static string JavaScriptDomain(string jsFileorPath)
        {
            return GetString("JavaScriptDomain", "http://localhost:9999/Content/js/") + jsFileorPath;
        }


        public static string CssDomain(string cssFileorPath)
        {
            return GetString("CssDomain", "http://localhost:9999/Content/css/") + cssFileorPath;
        }

        public static string ImageDomain(string imageFileorPath)
        {
            return GetString("ImageDomain", "http://localhost:9999/Content/images/") + imageFileorPath;
        }

        public static string ImageUploadCdnDomain(string imageFileorPath)
        {
            return GetString("ImageUploadCdnDomain", "http://uploadcdn.yingtao.co.uk/") + imageFileorPath;
        }

        public static string YingTaoUrl()
        {
            if (cacheService.Get("YingTaoUrl") == null)
            {
                cacheService.Insert("YingTaoUrl", GetString("YingTaoUrl", "http://yingtao.co.uk"), 3600, System.Web.Caching.CacheItemPriority.Default);
            }
            object o = cacheService.Get("YingTaoUrl");
            if (o != null)
            {
                return o.ToString();
            }
            return "";
        }

        public static string GoodsTransferLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "GoodsTransferDetail", "Index", id);
        }


        public static string GoodsBuyLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "GoodsBuyDetail", "Index", id);
        }


        public static string HouseTransferLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "HouseTransferDetail", "Index", id);
        }


        public static string HouseBuyLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "HouseBuyDetail", "Index", id);
        }


        public static string CarTransferLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "CarTransferDetail", "Index", id);
        }


        public static string CarBuyLink(int id)
        {
            return string.Format("{0}{1}/{2}/{3}", YingTaoUrl(), "CarBuyDetail", "Index", id);
        }






        public static string[] PictureMINE()
        {
            if (cacheService.Get("FxSitePictureMINE") == null)
            {
                cacheService.Insert("FxSitePictureMINE", GetString("PictureMIME", "jpg|jpeg|png|gif|bmp"), 3600, System.Web.Caching.CacheItemPriority.Normal);
            }
            var mines = (cacheService.Get("FxSitePictureMINE") as string).Split('|').ToArray();
            return mines;
        }


        public static string FormDomain
        {
            get { return GetString("FormDomain", "yingtao.co.uk"); }
        }



        #endregion

    }
}