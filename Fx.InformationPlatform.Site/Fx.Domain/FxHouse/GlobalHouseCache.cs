using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxHouse.IService;

namespace Fx.Domain.FxHouse
{
    public class GlobalHouseCache : IGolbalCacheHouse
    {

        public int InfoCount()
        {
            using (var context = new FxHouseContext())
            {
                return context.HouseBuyInfos.Count() + context.HouseTransferInfos.Count();
            }
        }
    }
}
