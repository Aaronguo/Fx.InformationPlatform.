using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site.Framework
{
    /// <summary>
    /// 剔除VB视图的检索,加速RazorViewEngine的查找
    /// </summary>
    public class CsharpRazorViewEngiee : RazorViewEngine
    {
        public CsharpRazorViewEngiee()
        {
            this.AreaMasterLocationFormats = VBFilter(this.AreaMasterLocationFormats);
            this.AreaPartialViewLocationFormats = VBFilter(this.AreaPartialViewLocationFormats);
            this.AreaViewLocationFormats = VBFilter(this.AreaViewLocationFormats);
            this.FileExtensions = VBFilter(this.FileExtensions);
            this.MasterLocationFormats = VBFilter(this.MasterLocationFormats);
            this.PartialViewLocationFormats = VBFilter(this.PartialViewLocationFormats);         
            this.ViewLocationFormats = VBFilter(this.ViewLocationFormats);          
        }

        private string[] VBFilter(string[] formats)
        {
            return formats.Where(r => !r.Contains("vb")).ToArray();
        }
    }
}