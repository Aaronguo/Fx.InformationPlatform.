using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxCar;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class CarTransferSearchModel
    {
        public List<CarTransferInfo> RightCars { get; set; }

        public List<CarTransferInfo> MainCars { get; set; }

        public List<CarTransferInfo> TopCars { get; set; }

        public string Ad { get; set; }

        public string Action { get; set; }


        /// <summary>
        /// 查询关键字
        /// </summary>
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

        public CarTransferSearchModel(int id)
        {
            this.RightCars = new List<CarTransferInfo>();
            this.MainCars = new List<CarTransferInfo>();
            this.CurrentIndex = id;
        }

        public CarTransferSearchModel()
        {

        }

        public void ModelCheck()
        {
            this.RightCars = this.RightCars == null ? new List<CarTransferInfo>() : this.RightCars;
            this.MainCars = this.MainCars == null ? new List<CarTransferInfo>() : this.MainCars;
            this.TopCars = this.TopCars == null ? new List<CarTransferInfo>() : this.TopCars;
        }
    }
}