using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class GoodsBuySearchModel
    {
       public List<GoodsBuyInfo> RightGoods { get; set; }

        public List<GoodsBuyInfo> MainGoods { get; set; }

        public List<GoodsBuyInfo> TopGoods { get; set; }

        public string Ad { get; set; }

        public string Action { get; set; }

        public string Key { get; set; }

        public int CurrentIndex { get; set; }

        public int StartIndex
        {
            get
            {
                // 11  1*10+1=11
                // 1  0*10+1=1
                int number = CurrentIndex / 10;
                if (number == 0)
                {
                    return 1;
                }
                return number * 10;
            }
        }

        public int EndIndex
        {
            get
            {
                int number = CurrentIndex / 10;
                return (number + 1) * 10;
            }
        }

        public GoodsBuySearchModel(int id)
        {
            this.RightGoods = new List<GoodsBuyInfo>();
            this.MainGoods = new List<GoodsBuyInfo>();
            this.CurrentIndex = id;
        }

        public GoodsBuySearchModel()
        {

        }

        public void ModelCheck()
        {
            this.RightGoods = this.RightGoods == null ? new List<GoodsBuyInfo>() : this.RightGoods;
            this.MainGoods = this.MainGoods == null ? new List<GoodsBuyInfo>() : this.MainGoods;
            this.TopGoods = this.TopGoods == null ? new List<GoodsBuyInfo>() : this.TopGoods;
        }
    }
}