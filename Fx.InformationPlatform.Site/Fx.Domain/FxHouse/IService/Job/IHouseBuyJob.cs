using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxHouse.IService
{
    public interface IHouseBuyJob
    {
        bool Authorizing(int houseId);

        bool AuthorizeSuccess(int houseId);

        bool AuthorizeFaild(int houseId, string msg);

        bool Publish(int houseId);

        bool Delay(int houseId);

        bool End(int houseId);

        bool NoDelete(int houseId);

        bool Delete(int houseId);
    }
}
