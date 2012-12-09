using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxCar;
using Fx.Entity.FxSite;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class CarBuySearchModel : SearchBase
    {
        public List<CarBuyInfo> RightCars { get; set; }

        public List<CarBuyInfo> MainCars { get; set; }

        public List<CarBuyInfo> TopCars { get; set; }

        public List<ChannelListDetail> ClcDatas
        {
            get
            {
                return cache.GetCarBuyChannel();
            }
        }

        public CarBuySearchModel(int id, SiteCache siteCache)
            : base(siteCache)            
        {
            this.CurrentIndex = id;
            this.cache = siteCache;
        }

      

        public override void CheckModel()
        {
            base.CheckModel();
            this.RightCars = this.RightCars == null ? new List<CarBuyInfo>() : this.RightCars;
            this.MainCars = this.MainCars == null ? new List<CarBuyInfo>() : this.MainCars;
            this.TopCars = this.TopCars == null ? new List<CarBuyInfo>() : this.TopCars;
        }
        
    }
}