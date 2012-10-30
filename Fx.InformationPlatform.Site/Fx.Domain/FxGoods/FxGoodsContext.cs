using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity.FxGoods;
using Fx.Infrastructure.Db;

namespace Fx.Domain.FxGoods
{
    public class FxGoodsContext : DbContext
    {
        static FxGoodsContext()
        {
            System.Data.Entity.Database.SetInitializer(new FxGoodsInitializer());
        }

        public FxGoodsContext()
            : base(Connection.CreateConnection(FxConnection.FxGoods), false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CarPublishInfo> CarPublishInfos { get; set; }
    }
}
