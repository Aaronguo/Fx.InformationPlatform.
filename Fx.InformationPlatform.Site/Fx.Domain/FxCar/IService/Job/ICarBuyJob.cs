using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxCar.IService
{
    public interface ICarBuyJob
    {
        bool Authorizing(int carId);

        bool AuthorizeSuccess(int carId);

        bool AuthorizeFaild(int carId, string msg);

        bool Publish(int carId);

        bool Delay(int carId);

        bool End(int carId);

        bool NoDelete(int carId);
    }
}
