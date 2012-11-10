using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site
{
    public static class UploadFileHelper
    {
        /// <summary>
        /// 获取页面中指定名称的上传文件和名称
        /// </summary>
        /// <param name="uploadFile"></param>
        /// <param name="name">控件名称</param>
        /// <returns></returns>
        public static List<HttpPostedFileBase> GetFile(this List<HttpPostedFileBase> uploadFile, string name)
        {
            List<HttpPostedFileBase> files=new List<HttpPostedFileBase> ();
            foreach (var item in uploadFile)
            {
                if (item.ContentLength > 0 && AppSettings.PictureMINE().Contains(item.ContentType.ToLower()))
                {
                    
                }
            }
            return files;
        }
    }
}