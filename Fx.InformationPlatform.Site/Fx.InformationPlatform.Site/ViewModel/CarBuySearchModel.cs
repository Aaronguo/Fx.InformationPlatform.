using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxCar;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class CarBuySearchModel
    {
        public List<CarBuyInfo> RightCars { get; set; }

        public List<CarBuyInfo> MainCars { get; set; }

        public List<CarBuyInfo> TopCars { get; set; }

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

        public CarBuySearchModel(int id)
        {
            this.RightCars = new List<CarBuyInfo>();
            this.MainCars = new List<CarBuyInfo>();
            this.CurrentIndex = id;
        }

        public CarBuySearchModel()
        {

        }
        
        public void ModelCheck()
        {
            this.RightCars = this.RightCars == null ? new List<CarBuyInfo>() : this.RightCars;
            this.MainCars = this.MainCars == null ? new List<CarBuyInfo>() : this.MainCars;
            this.TopCars = this.TopCars == null ? new List<CarBuyInfo>() : this.TopCars;
        }
    }
}