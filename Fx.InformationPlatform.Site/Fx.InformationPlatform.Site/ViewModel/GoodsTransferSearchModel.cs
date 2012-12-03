using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class GoodsTransferSearchModel
    {
        public List<GoodsTransferInfo> RightGoods { get; set; }

        public List<GoodsTransferInfo> MainGoods { get; set; }

        public List<GoodsTransferInfo> TopGoods { get; set; }

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

        public bool IsChangeByGoods { get; set; }

        public bool IsChangeByPrice { get; set; }

        public GoodsTransferSearchModel(int id)
        {
            this.RightGoods = new List<GoodsTransferInfo>();
            this.MainGoods = new List<GoodsTransferInfo>();
            this.CurrentIndex = id;
            this.IsChangeByGoods = true;
            this.IsChangeByPrice = true;
        }


        public GoodsTransferSearchModel()
        {

        }

        public void ModelCheck()
        {
            this.RightGoods = this.RightGoods == null ? new List<GoodsTransferInfo>() : this.RightGoods;
            this.MainGoods = this.MainGoods == null ? new List<GoodsTransferInfo>() : this.MainGoods;
            this.TopGoods = this.TopGoods == null ? new List<GoodsTransferInfo>() : this.TopGoods;
        }
    }
}