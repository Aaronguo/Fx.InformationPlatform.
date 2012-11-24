using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.Mapping;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate
{
    public class FxAggregateContext : DbContext, IDisposable
    {
        static FxAggregateContext()
        {
            //System.Data.Entity.Database.SetInitializer(new FxCarInitializer());
        }

        public FxAggregateContext()
            : base("fx.aggregate-sqlserver")
        {

        }

        public FxAggregateContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Favorites_Mapping());
        }

        public DbSet<Favorite> Favorites { get; set; }
    }
}
