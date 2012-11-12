using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxHouse
{
    public class FxHouseInitializer : DropCreateDatabaseAlways<FxHouseContext>
    {
        protected override void Seed(FxHouseContext context)
        {
            base.Seed(context);
        }
    }
}
