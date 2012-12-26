using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.FxGoods;
using Fx.Entity.FxSite;
using FxCacheService.FxGoods;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class GoodsTransferSearchModel : SearchBase
    {
        public List<GoodsTransferInfo> RightGoods { get; set; }

        public List<GoodsTransferInfo> MainGoods { get; set; }

        public List<GoodsTransferInfo> TopGoods { get; set; }

        public bool IsChangeByGoods { get; set; }

        public bool IsChangeByPrice { get; set; }

      

        public GoodsTransferSearchModel(int id)
            : base()
        {
            this.CurrentIndex = id;
            this.IsChangeByGoods = true;
            this.IsChangeByPrice = true;
            this.TopGoods = DependencyResolver.Current.GetService<GoodsCache>().GetGoodsTransferTopShow();
        }

        public List<ChannelList> ClcDatas
        {
            get
            {
                return siteCache.GetGoodsChannel();
            }
        }

        public override void CheckModel()
        {
            this.RightGoods = this.RightGoods == null ? new List<GoodsTransferInfo>() : this.RightGoods;
            this.MainGoods = this.MainGoods == null ? new List<GoodsTransferInfo>() : this.MainGoods;
            this.TopGoods = this.TopGoods == null ? new List<GoodsTransferInfo>() : this.TopGoods;
        }
    }
}