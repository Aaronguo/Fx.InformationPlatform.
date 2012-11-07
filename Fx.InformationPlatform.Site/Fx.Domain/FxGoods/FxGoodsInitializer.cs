using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    public class FxGoodsInitializer : CreateDatabaseIfNotExists<FxGoodsContext>
    {
        protected override void Seed(FxGoodsContext context)
        {
            base.Seed(context);
            context.SaveChanges();
        }
    }
}
