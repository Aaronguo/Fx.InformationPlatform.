using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxCar
{
    public class CarBuyInfo : CarBase
    {
        public int CarBuyInfoId { get; set; }

        public virtual ICollection<CarBuyLog> Logs { get; set; }

        public CarBuyInfo()
        {
            this.Logs = new List<CarBuyLog>();
        }
    }
}
