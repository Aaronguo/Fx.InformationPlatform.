using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Domain.FxSite
{
    public class FxSiteInitializer : CreateDatabaseIfNotExists<FxSiteContext>
    {
        protected override void Seed(FxSiteContext context)
        {
            base.Seed(context);
        }
    }
}
