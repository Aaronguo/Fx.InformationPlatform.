using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxHouse;
using Fx.Entity.FxSite;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class HouseBuySearchModel : SearchBase
    {
        public List<HouseBuyInfo> RightHouse { get; set; }

        public List<HouseBuyInfo> MainHouse { get; set; }

        public List<HouseBuyInfo> TopHouse { get; set; }

        public List<ChannelListDetail> ClcDatas
        {
            get
            {
                return cache.GetHouseBuyChannel();
            }
        }

        public HouseBuySearchModel(int id, SiteCache siteCache)
            : base(siteCache)
        {
            this.CurrentIndex = id;
            this.cache = siteCache;
        }

        public override void CheckModel()
        {
            this.RightHouse = this.RightHouse == null ? new List<HouseBuyInfo>() : this.RightHouse;
            this.MainHouse = this.MainHouse == null ? new List<HouseBuyInfo>() : this.MainHouse;
            this.TopHouse = this.TopHouse == null ? new List<HouseBuyInfo>() : this.TopHouse;
        }
    }
}