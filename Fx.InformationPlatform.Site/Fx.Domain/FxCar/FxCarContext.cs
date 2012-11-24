using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.Mapping;
using Fx.Domain.Mapping;
using Fx.Entity;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar
{
    public class FxCarContext : DbContext, IDisposable
    {
        static FxCarContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxCarInitializer());
        }

        public FxCarContext()
            : base("fx.car-sqlserver")
        {

        }

        public FxCarContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CarBuyInfo_Mapping());
            modelBuilder.Configurations.Add(new CarTransferInfo_Mapping());
            modelBuilder.Configurations.Add(new TransferPicture_Mapping());
        }

        public DbSet<CarTransferInfo> CarTransferInfos { get; set; }
        public DbSet<CarBuyInfo> CarBuyInfos { get; set; }

        public DbSet<PictureCdnError> PictureCdnErrors { get; set; }
    }
}
