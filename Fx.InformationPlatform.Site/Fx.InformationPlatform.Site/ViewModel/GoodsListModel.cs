using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 数码产品 居家用品 衣服鞋包 文化生活 其他
    /// </summary>
    public class GoodsListModel
    {
        public List<GoodsTransferInfo> Electronics { get; set; }
        public List<GoodsTransferInfo> HomeSupplies { get; set; }
        public List<GoodsTransferInfo> Fashions { get; set; }
        public List<GoodsTransferInfo> CultureLifes { get; set; }
        public List<GoodsTransferInfo> Others { get; set; }


        public GoodsListModel()
        {
            this.Electronics = new List<GoodsTransferInfo>();
            this.HomeSupplies = new List<GoodsTransferInfo>();
            this.Fashions = new List<GoodsTransferInfo>();
            this.CultureLifes = new List<GoodsTransferInfo>();
            this.Others = new List<GoodsTransferInfo>();
        }
    }
}