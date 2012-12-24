using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.FxBrower.Mapping;
using Fx.Entity.FxBrower;

namespace Fx.Domain.FxBrower
{
    public class FxBrowerContext : DbContext, IDisposable
    {
        static FxBrowerContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxBrowerInitializer());
        }

        public FxBrowerContext()
            : base("fx.collectinfo-sqlserver")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Brower_Mapping());

        }

        public DbSet<Brower> Browers { get; set; }

    }
}
