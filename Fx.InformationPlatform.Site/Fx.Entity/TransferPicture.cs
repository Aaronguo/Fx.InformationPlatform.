using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    public class TransferPicture
    {
        public int TransferPictureId { get; set; }

        public TransferPictureCatagroy TransferPictureCatagroy { get; set; }

        /// <summary>
        /// 原始根目录
        /// </summary>
        public string PhysicalPath { get; set; }

        public string ImageUrl { get; set; }

        public bool IsCdn { get; set; }

        public string CdnUrl { get; set; }
    }

    public enum TransferPictureCatagroy
    {
        Head=0,
        Other=1,
        Bad=2
    }
}
