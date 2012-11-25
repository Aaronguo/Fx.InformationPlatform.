using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Fx.Domain.FxCar.IService;

namespace Fx.Domain.FxCar
{
   public class FxTransferCarService:ITransferCar
    {
        public Entity.FxCar.CarTransferInfo Get(int Id)
        {
            using (FxCarContext context = new FxCarContext())
            {
                return context.CarTransferInfos.Include(r => r.Pictures)
                    .Where(r => r.CarTransferInfoId == Id).FirstOrDefault();
            }
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
