using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.FxCar;
using Fx.Entity.FxSite;
using FxCacheService.FxCar;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class CarTransferSearchModel : SearchBase
    {
        public List<CarTransferInfo> RightCars { get; set; }

        public List<CarTransferInfo> MainCars { get; set; }

        public List<CarTransferInfo> TopCars { get; set; }

        public List<ChannelListDetail> ClcDatas
        {
            get
            {
                return cache.GetCarTransferChannel();
            }
        }

        public CarTransferSearchModel(int id)
            :base()
        {
            this.CurrentIndex = id;
            this.TopCars = DependencyResolver.Current.GetService<CarCache>().GetCarTransferTopShow();
        }

        public override void CheckModel()
        {
            this.RightCars = this.RightCars == null ? new List<CarTransferInfo>() : this.RightCars;
            this.MainCars = this.MainCars == null ? new List<CarTransferInfo>() : this.MainCars;
            this.TopCars = this.TopCars == null ? new List<CarTransferInfo>() : this.TopCars;
        }
    }
}