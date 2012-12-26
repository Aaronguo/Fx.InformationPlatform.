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
    public class GoodsBuySearchModel : SearchBase
    {
        public List<GoodsBuyInfo> RightGoods { get; set; }

        public List<GoodsBuyInfo> MainGoods { get; set; }

        public List<GoodsBuyInfo> TopGoods { get; set; }

        public bool IsChangeByGoods { get; set; }

        public bool IsChangeByPrice { get; set; }

        public List<ChannelList> ClcDatas
        {
            get
            {
                return siteCache.GetGoodsChannel();
            }
        }

        public GoodsBuySearchModel(int id)
            : base()
        {
            this.CurrentIndex = id;
            this.IsChangeByGoods = true;
            this.IsChangeByPrice = true;
            this.TopGoods = System.Web.Mvc.DependencyResolver.Current.GetService<GoodsCache>().GetGoodsBuyTopShow();
        }

        public override void CheckModel()
        {
            this.RightGoods = this.RightGoods == null ? new List<GoodsBuyInfo>() : this.RightGoods;
            this.MainGoods = this.MainGoods == null ? new List<GoodsBuyInfo>() : this.MainGoods;
            this.TopGoods = this.TopGoods == null ? new List<GoodsBuyInfo>() : this.TopGoods;
        }
    }
}