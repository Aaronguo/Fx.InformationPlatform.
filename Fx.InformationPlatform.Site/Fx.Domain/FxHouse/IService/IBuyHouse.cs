﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.IService
{
    public interface IBuyHouse
    {
        HouseBuyInfo Get(int Id);

        bool SaveBuyHouse(HouseBuyInfo goods);
    }
}
