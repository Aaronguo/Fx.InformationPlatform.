using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    public enum ChannelCatagroy
    {
        [Description("车辆转让")]
        FxCarTransfer = 0,
        [Description("车辆求购")]
        FxCarBuy = 1,
        [Description("二手转让")]
        FxGoodsTransfer = 2,
        [Description("二手转让")]
        FxGoodsBuy = 3,
        [Description("房屋转让")]
        FxHouseTrasnfer = 4,
        [Description("房屋转让")]
        FxHouseBuy = 5,
    }
}
