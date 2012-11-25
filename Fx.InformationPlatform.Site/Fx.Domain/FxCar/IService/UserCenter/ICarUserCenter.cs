using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.IService.UserCenter
{
    public interface ICarUserCenter
    {
        List<CarTransferInfo> GetTransfers(string email);

        List<CarBuyInfo> GetBuys(string email);

        List<CarTransferInfo> GetAdminTransfers(int page);

        List<CarBuyInfo> GetAdminBuys(int page);
    }
}
