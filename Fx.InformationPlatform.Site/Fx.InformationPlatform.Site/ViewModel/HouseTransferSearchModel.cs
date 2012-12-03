using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxHouse;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class HouseTransferSearchModel : SearchBase
    {
        public List<HouseTransferInfo> RightHouse { get; set; }

        public List<HouseTransferInfo> MainHouse { get; set; }

        public List<HouseTransferInfo> TopHouse { get; set; }

        public HouseTransferSearchModel(int id)
        {
            this.CurrentIndex = id;
        }

        public HouseTransferSearchModel()
        {

        }

        public override void CheckModel()
        {
            this.RightHouse = this.RightHouse == null ? new List<HouseTransferInfo>() : this.RightHouse;
            this.MainHouse = this.MainHouse == null ? new List<HouseTransferInfo>() : this.MainHouse;
            this.TopHouse = this.TopHouse == null ? new List<HouseTransferInfo>() : this.TopHouse;
        }
    }
}