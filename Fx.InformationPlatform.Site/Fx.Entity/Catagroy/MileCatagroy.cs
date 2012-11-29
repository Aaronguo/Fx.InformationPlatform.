using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Fx.Entity.Catagroy
{
    public enum MileCatagroy
    {
        [Description("100英里以下")]
        _100英里以下 = 1,
        [Description("5000英里以下")]
        _5000英里以下 = 2,
        [Description("10000英里以下")]
        _10000英里以下 = 3,
        [Description("20000英里以下")]
        _20000英里以下 = 4,
        [Description("40000英里以下")]
        _40000英里以下 = 5,
        [Description("60000英里以下")]
        _60000英里以下 = 6,
        [Description("80000英里以下")]
        _80000英里以下 = 7,
        [Description("100000英里以下")]
        _100000英里以下 = 8,
        [Description("100000英里以上")]
        _100000英里以上 = 9
    }
}
