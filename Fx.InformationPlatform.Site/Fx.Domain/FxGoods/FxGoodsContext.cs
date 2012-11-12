using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxGoods.Mapping;
using Fx.Domain.FxGoods.Mapping;
using Fx.Domain.Mapping;
using Fx.Entity.FxGoods;
using Fx.Infrastructure.Db;

namespace Fx.Domain.FxGoods
{
    public class FxGoodsContext : DbContext
    {
        static FxGoodsContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxGoodsInitializer());
        }

        public FxGoodsContext()
            : base("fx.goods-mysql")//
        {

        }

        public FxGoodsContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new GoodsBuyInfo_Mapping());
            modelBuilder.Configurations.Add(new GoodsTransferInfo_Mapping());
            modelBuilder.Configurations.Add(new TransferPicture_Mapping());
            modelBuilder.Configurations.Add(new BuyPicture_Mapping());
        }

        public DbSet<GoodsTransferInfo> GoodsTransferInfos { get; set; }
        public DbSet<GoodsBuyInfo> GoodsBuyInfos { get; set; }
    }
}
