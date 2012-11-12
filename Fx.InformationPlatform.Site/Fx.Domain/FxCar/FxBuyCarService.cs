using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar
{
    public class FxBuyCarService : IBuyCar
    {

        public Entity.FxCar.CarBuyInfo Get(int Id)
        {
            throw new NotImplementedException();
        }

        public bool SaveBuyCar(CarBuyInfo car)
        {
            using (FxCarContext context = new FxCarContext())
            {
                context.CarBuyInfos.Add(car);
                context.SaveChanges();
            }
            return car.CarBuyInfoId > 0;
        }
    }
}
