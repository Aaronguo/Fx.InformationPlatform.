using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxHouse.IService.UserCenter;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.UserCenterImp
{
    public class HouseUserCenter : IHouseUserCenter
    {
        public List<HouseTransferInfo> GetTransfers(string email)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        public List<HouseBuyInfo> GetBuys(string email)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseBuyInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }


        public List<HouseTransferInfo> GetAdminTransfers(int page = 0)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos
                    .OrderByDescending(r => r.HouseTransferInfoId)
                    //.Include(r => r.UserAccount)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }

        public List<HouseBuyInfo> GetAdminBuys(int page = 0)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseBuyInfos
                    .OrderByDescending(r => r.HouseBuyInfoId)
                    //.Include(r => r.UserAccount)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                     .Skip(page * 100).Take(100)
                    .ToList();
            }
        }
    }
}
