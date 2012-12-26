using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.FxHouse;
using Fx.Entity.FxSite;
using FxCacheService.FxHouse;
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
                return siteCache.GetHouseBuyChannel();
            }
        }

        public HouseBuySearchModel(int id)
            : base()
        {
            this.CurrentIndex = id;
            this.TopHouse = DependencyResolver.Current.GetService<HouseCache>().GetHouseBuyTopShow();
        }

        public override void CheckModel()
        {
            this.RightHouse = this.RightHouse == null ? new List<HouseBuyInfo>() : this.RightHouse;
            this.MainHouse = this.MainHouse == null ? new List<HouseBuyInfo>() : this.MainHouse;
            this.TopHouse = this.TopHouse == null ? new List<HouseBuyInfo>() : this.TopHouse;
        }
    }
}