using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxGoods
{
    public class GoodsTransferInfo : GoodsBase
    {
        public int GoodsTransferInfoId { get; set; }

        /// <summary>
        /// 新旧程度
        /// </summary>
        public int GoodsconditonId { get; set; }

        /// <summary>
        /// 物品功能问题
        /// </summary>
        public string GoodsConditionMsg { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        //public bool isTopshow { get; set; }

        /// <summary>
        /// 置顶排序
        /// </summary>
        //public int SortedTopshow { get; set; }


        public virtual List<TransferPicture> Pictures { get; set; }

        public GoodsTransferInfo()
        {          
            this.Pictures = new List<TransferPicture>();
        }
    }
}
