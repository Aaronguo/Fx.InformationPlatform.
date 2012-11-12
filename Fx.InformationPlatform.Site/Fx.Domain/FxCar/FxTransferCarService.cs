using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;

namespace Fx.Domain.FxCar
{
   public class FxTransferCarService:ITransferCar
    {

        public Entity.FxCar.CarTransferInfo Get(int Id)
        {
            throw new NotImplementedException();
        }

        public bool SaveTransferCar(Entity.FxCar.CarTransferInfo car)
        {
            using (FxCarContext context = new FxCarContext())
            {
                context.CarTransferInfos.Add(car);
                context.SaveChanges();
            }
            return car.CarTransferInfoId > 0;
        }
    }
}
