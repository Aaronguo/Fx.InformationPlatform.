using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxCar.IService
{
    public interface ICarBuyJob
    {
        bool AuthorizeSuccess(int carId);

        bool AuthorizeFaild(int carId);

        bool Publish(int carId);     

        bool Delay(int carId);

        bool End(int carId);
    }
}
