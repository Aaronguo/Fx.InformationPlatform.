using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxCar
{
   public class CarBuyLog
    {
       public int CarBuyLogId { get; set; }

       public string OperteName { get; set; }

       public string Source { get; set; }

       public virtual DateTime OperteTime { get; set; }

       public CarBuyLog()
       {
           this.OperteTime = DateTime.Now;
       }
    }
}
