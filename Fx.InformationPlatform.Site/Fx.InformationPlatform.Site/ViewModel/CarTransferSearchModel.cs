using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxCar;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class CarTransferSearchModel : SearchBase
    {
        public List<CarTransferInfo> RightCars { get; set; }

        public List<CarTransferInfo> MainCars { get; set; }

        public List<CarTransferInfo> TopCars { get; set; }

        public CarTransferSearchModel(int id)
        {
            this.CurrentIndex = id;
        }

        public CarTransferSearchModel()
        {

        }

        public override void CheckModel()
        {
            this.RightCars = this.RightCars == null ? new List<CarTransferInfo>() : this.RightCars;
            this.MainCars = this.MainCars == null ? new List<CarTransferInfo>() : this.MainCars;
            this.TopCars = this.TopCars == null ? new List<CarTransferInfo>() : this.TopCars;
        }
    }
}