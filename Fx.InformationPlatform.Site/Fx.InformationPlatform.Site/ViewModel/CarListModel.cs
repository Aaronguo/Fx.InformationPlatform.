using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxCar;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class CarListModel
    {
        public List<CarTransferInfo> SecondHandCars { get; set; }

        public CarListModel()
        {
            this.SecondHandCars = new List<CarTransferInfo>();
        }
    }
}