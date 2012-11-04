using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site
{
    public class AppSettings
    {
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

 



        //public static double CacheSettingsTimeOut
        //{
        //    get { return GetDouble("CacheSettingsTimeOut", 600); }
        //}

        //public static byte CacheSettingsPriority
        //{
        //    get { return GetByte("CacheSettingsPriority", 3); }
        //}

        #endregion

    }
}