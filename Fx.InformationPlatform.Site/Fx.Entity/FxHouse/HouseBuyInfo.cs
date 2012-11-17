using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxHouse
{
    public class HouseBuyInfo : HouseBase
    {
        public int HouseBuyInfoId { get; set; }

        public virtual ICollection<HouseBuyLog> Logs { get; set; }
    }
}
