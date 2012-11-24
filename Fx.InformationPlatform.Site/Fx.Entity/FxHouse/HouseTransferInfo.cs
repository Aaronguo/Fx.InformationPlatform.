using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxHouse
{
    public class HouseTransferInfo : HouseBase
    {
        public int HouseTransferInfoId { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string RoadName { get; set; }

        public virtual List<TransferPicture> Pictures { get; set; }

        public virtual ICollection<HouseTransferLog> Logs { get; set; }

        public HouseTransferInfo()
        {
            this.Pictures = new List<TransferPicture>();
            this.Logs = new List<HouseTransferLog>();
        }
    }
}
