using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxHouse;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class HouseTransferSearchModel
    {
        public List<HouseTransferInfo> RightHouse { get; set; }

        public List<HouseTransferInfo> MainHouse { get; set; }

        public List<HouseTransferInfo> TopHouse { get; set; }

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

        public HouseTransferSearchModel(int id)
        {
            this.RightHouse = new List<HouseTransferInfo>();
            this.MainHouse = new List<HouseTransferInfo>();
            this.CurrentIndex = id;
        }

        public HouseTransferSearchModel()
        {

        }

        public void ModelCheck()
        {
            this.RightHouse = this.RightHouse == null ? new List<HouseTransferInfo>() : this.RightHouse;
            this.MainHouse = this.MainHouse == null ? new List<HouseTransferInfo>() : this.MainHouse;
            this.TopHouse = this.TopHouse == null ? new List<HouseTransferInfo>() : this.TopHouse;
        }
    }
}