using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxBrower
{
    public class FxBrowerInitializer :  DropCreateDatabaseIfModelChanges<FxBrowerContext>
    {
        protected override void Seed(FxBrowerContext context)
        {
            base.Seed(context);
        }
    }
}
