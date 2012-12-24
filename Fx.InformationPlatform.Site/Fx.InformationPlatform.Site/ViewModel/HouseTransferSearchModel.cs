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
    public class HouseTransferSearchModel : SearchBase
    {
        public List<HouseTransferInfo> RightHouse { get; set; }

        public List<HouseTransferInfo> MainHouse { get; set; }

        public List<HouseTransferInfo> TopHouse { get; set; }

        public List<ChannelListDetail> ClcDatas
        {
            get
            {
                return cache.GetHouseTransferChannel();
            }
        }

        public HouseTransferSearchModel(int id)
            : base()
        {
            this.CurrentIndex = id;
            this.TopHouse = DependencyResolver.Current.GetService<HouseCache>().GetHouseTransferTopShow();
        }


        public override void CheckModel()
        {
            this.RightHouse = this.RightHouse == null ? new List<HouseTransferInfo>() : this.RightHouse;
            this.MainHouse = this.MainHouse == null ? new List<HouseTransferInfo>() : this.MainHouse;
            this.TopHouse = this.TopHouse == null ? new List<HouseTransferInfo>() : this.TopHouse;
        }
    }
}