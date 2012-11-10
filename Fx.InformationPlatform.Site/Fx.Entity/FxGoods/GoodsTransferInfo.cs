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
        /// 交互物品信息
        /// </summary>
        public string ChangeMsg { get; set; }



        /// <summary>
        /// 新旧程度
        /// </summary>
        public int GoodsconditonId { get; set; }

        /// <summary>
        /// 物品功能问题
        /// </summary>
        public string GoodsConditionMsg { get; set; }

        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        public bool isDelete { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool isPublish { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool isTopshow { get; set; }

        /// <summary>
        /// 置顶排序
        /// </summary>
        public int SortedTopshow { get; set; }


        public virtual List<TransferPicture> Pictures { get; set; }

        public GoodsTransferInfo()
        {
            this.isDelete = false;
            this.isPublish = false;
            this.isTopshow = false;
            this.Pictures = new List<TransferPicture>();
        }
    }
}
