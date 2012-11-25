using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxHouse.IService;

namespace Fx.Domain.FxHouse
{
    public class FxBuyHouseService : IBuyHouse
    {
        public Entity.FxHouse.HouseBuyInfo Get(int Id)
        {
            using (FxHouseContext context = new FxHouseContext())
            {
                return context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == Id).FirstOrDefault();
            }
        }

        public bool SaveBuyHouse(Entity.FxHouse.HouseBuyInfo house)
        {
            using (FxHouseContext context = new FxHouseContext())
            {
                context.HouseBuyInfos.Add(house);
                context.SaveChanges();
            }
            return house.HouseBuyInfoId > 0;
        }
    }
}
