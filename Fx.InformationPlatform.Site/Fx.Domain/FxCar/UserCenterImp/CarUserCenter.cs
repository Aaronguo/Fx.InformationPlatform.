using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxCar.IService.UserCenter;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.UserCenterImp
{
    public class CarUserCenter : ICarUserCenter
    {

        public List<CarTransferInfo> GetTransfers(string email)
        {
            using (var content = new FxCarContext())
            {
                return content.CarTransferInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        public List<CarBuyInfo> GetBuys(string email)
        {
            using (var content = new FxCarContext())
            {
                return content.CarBuyInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }


        public List<CarTransferInfo> GetAdminTransfers(int page = 0)
        {
            using (var content = new FxCarContext())
            {
                return content.CarTransferInfos
                    .OrderByDescending(r => r.CarTransferInfoId)
                    //.Include(r => r.UserAccount)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }

        public List<CarBuyInfo> GetAdminBuys(int page = 0)
        {
            using (var content = new FxCarContext())
            {
                return content.CarBuyInfos
                    .OrderByDescending(r => r.CarBuyInfoId)
                    //.Include(r => r.UserAccount)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }
    }
}
