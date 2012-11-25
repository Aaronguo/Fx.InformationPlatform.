using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Fx.Domain.FxHouse.IService;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse
{
   public  class FxTransferHouseService:ITransferHouse
    {

        public Entity.FxHouse.HouseTransferInfo Get(int Id)
        {
            using (FxHouseContext context = new FxHouseContext())
            {
                return context.HouseTransferInfos.Include(r => r.Pictures)
                    .Where(r => r.HouseTransferInfoId == Id).FirstOrDefault();
            }
        }

        public bool SaveTransferHouse(HouseTransferInfo house)
        {
            using (var context = new FxHouseContext())
            {
                context.HouseTransferInfos.Add(house);
                context.SaveChanges();
            }
            return house.HouseTransferInfoId > 0;
        }
    }
}
