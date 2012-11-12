using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    public class BuyPicture
    {
        public virtual int BuyPictureId { get; set; }

        public int BuyPictureCatagroy { get; set; }

        /// <summary>
        /// 原始根目录
        /// </summary>
        public virtual string PhysicalPath { get; set; }

        public string ImageUrl { get; set; }

        public bool IsCdn { get; set; }

        public string CdnUrl { get; set; }

        public BuyPicture()
        {
            this.IsCdn = false;
        }
    }
}
