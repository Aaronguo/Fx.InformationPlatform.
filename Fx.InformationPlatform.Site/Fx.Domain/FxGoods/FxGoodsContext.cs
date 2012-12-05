using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using Fx.Domain.FxGoods.Mapping;
using Fx.Entity;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    public class FxGoodsContext : DbContext, IDisposable
    {
        static FxGoodsContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxGoodsInitializer());
        }

        public FxGoodsContext()
            : base("fx.goods-sqlserver")
        {

        }

        public FxGoodsContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new GoodsBuyInfo_Mapping());
            //modelBuilder.Configurations.Add(new GoodsTransferInfo_Mapping());
            //modelBuilder.Configurations.Add(new TransferPicture_Mapping());
            //modelBuilder.Configurations.Add(new BuyPicture_Mapping());


            modelBuilder.Configurations.Add(new BuyPicture_Mapping());
            modelBuilder.Configurations.Add(new GoodsBuyInfo_Mapping());
            modelBuilder.Configurations.Add(new GoodsBuyLogs_Mapping());
            modelBuilder.Configurations.Add(new GoodsTransferInfo_Mapping());
            modelBuilder.Configurations.Add(new GoodsTransferLogs_Mapping());
            modelBuilder.Configurations.Add(new PictureCdnErrors_Mapping());
            modelBuilder.Configurations.Add(new TransferPicture_Mapping());

        }

        public DbSet<GoodsTransferInfo> GoodsTransferInfos { get; set; }
        public DbSet<GoodsBuyInfo> GoodsBuyInfos { get; set; }
        public DbSet<PictureCdnError> PictureCdnErrors { get; set; }


        public ObjectContext ObjectContent
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }
    }
}
