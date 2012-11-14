using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.FxHouse.Mapping;
using Fx.Domain.Mapping;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse
{
    public class FxHouseContext : DbContext
    {
        static FxHouseContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxHouseInitializer());
        }

        public FxHouseContext()
            : base("fx.house-mysql")
        {

        }

        public FxHouseContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new HouseBuyInfo_Mapping());
            modelBuilder.Configurations.Add(new HouseTransferInfo_Mapping());
            modelBuilder.Configurations.Add(new TransferPicture_Mapping());
        }

        public DbSet<HouseTransferInfo> HouseTransferInfos { get; set; }
        public DbSet<HouseBuyInfo> HouseBuyInfos { get; set; }
    }
}
