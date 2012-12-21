using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;

namespace Fx.Domain.FxCar
{
    public class GlobalCacheCar : IGlobalCacheCar
    {
        public int InfoCount()
        {
            using (var context=new FxCarContext())
            {
                return context.CarBuyInfos.Count() + context.CarTransferInfos.Count();
            }
        }
    }
}
