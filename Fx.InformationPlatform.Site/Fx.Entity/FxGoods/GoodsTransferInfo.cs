using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxGoods
{
    public class GoodsTransferInfo : TransferEntity
    {
        public int GoodsTransferInfoId { get; set; }

        /// <summary>
        /// 是否换物
        /// </summary>
        public bool IsChange { get; set; }

        /// <summary>
        /// 新旧程度
        /// </summary>
        public int GoodsconditonId { get; set; }

        public ICollection<TransferPicture> Pictures { get; set; }
    }
}
