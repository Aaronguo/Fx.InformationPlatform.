using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.IService
{
    public interface IBuyCar
    {
        CarBuyInfo Get(int Id);

        bool SaveBuyCar(CarBuyInfo car);
    }
}
