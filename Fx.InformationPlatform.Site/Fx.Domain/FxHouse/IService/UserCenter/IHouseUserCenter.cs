using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.IService.UserCenter
{
    public interface IHouseUserCenter
    {
        List<HouseTransferInfo> GetTransfers(string email);

        List<HouseBuyInfo> GetBuys(string email);

        List<HouseTransferInfo> GetAdminTransfers(int page);

        List<HouseBuyInfo> GetAdminBuys(int page);
    }
}
