using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class GoodsBuySearchModel : SearchBase
    {
       public List<GoodsBuyInfo> RightGoods { get; set; }

        public List<GoodsBuyInfo> MainGoods { get; set; }

        public List<GoodsBuyInfo> TopGoods { get; set; }

        public GoodsBuySearchModel(int id)
        {
            this.CurrentIndex = id;
        }

        public GoodsBuySearchModel()
        {

        }

        public override void CheckModel()
        {
            this.RightGoods = this.RightGoods == null ? new List<GoodsBuyInfo>() : this.RightGoods;
            this.MainGoods = this.MainGoods == null ? new List<GoodsBuyInfo>() : this.MainGoods;
            this.TopGoods = this.TopGoods == null ? new List<GoodsBuyInfo>() : this.TopGoods;
        }
    }
}