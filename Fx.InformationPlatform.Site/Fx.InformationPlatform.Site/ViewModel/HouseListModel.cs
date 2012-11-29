using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxHouse;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class HouseListModel
    {
        public List<HouseTransferInfo> CommercialProperties { get; set; }

        public List<HouseTransferInfo> Properties { get; set; }

        public HouseListModel()
        {
            this.CommercialProperties = new List<HouseTransferInfo>();
            this.Properties = new List<HouseTransferInfo>();
        }
    }
}