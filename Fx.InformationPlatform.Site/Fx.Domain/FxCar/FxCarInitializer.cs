using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxCar
{
    public class FxCarInitializer : DropCreateDatabaseAlways<FxCarContext>
    {
        protected override void Seed(FxCarContext context)
        {
            base.Seed(context);
        }
    }
}
