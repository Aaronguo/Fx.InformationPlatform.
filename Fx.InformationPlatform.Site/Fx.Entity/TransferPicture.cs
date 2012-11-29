using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    public class TransferPicture
    {
        public virtual int TransferPictureId { get; set; }

        public int TransferPictureCatagroy { get; set; }

        /// <summary>
        /// 原始根目录
        /// </summary>
        public virtual string PhysicalPath { get; set; }

        public string ImageUrl { get; set; }

        public bool IsCdn { get; set; }

        public string CdnUrl { get; set; }

        public string MinImageUrl { get; set; }

        public TransferPicture()
        {
            this.IsCdn = false;
        }
    }
}
