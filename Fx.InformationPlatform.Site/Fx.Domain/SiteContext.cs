using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.Account.Mapping;
using Fx.Domain.Account.Mapping.Other;
using Fx.Domain.FxSite.Mapping;
using Fx.Entity.FxSite;
using Fx.Entity.MemberShip;
using Fx.Infrastructure.Db;

namespace Fx.Domain
{
    public class SiteContext : DbContext
    {
        static SiteContext()
        {
            System.Data.Entity.Database.SetInitializer(new SiteInitializer());
        }

        public SiteContext()
            : base(Connection.CreateConnection(FxConnection.FxSite),true)
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Configurations.Add(new Applications_Mapping());
            modelBuilder.Configurations.Add(new Membership_Mapping());
            modelBuilder.Configurations.Add(new Paths_Mapping());
            modelBuilder.Configurations.Add(new PersonalizationAllUsers_Mapping());
            modelBuilder.Configurations.Add(new PersonalizationPerUser_Mapping());
            modelBuilder.Configurations.Add(new Profile_Mapping());
            modelBuilder.Configurations.Add(new Roles_Mapping());
            modelBuilder.Configurations.Add(new SchemaVersions_Mapping());
            modelBuilder.Configurations.Add(new Users_Mapping());
            modelBuilder.Configurations.Add(new WebEvent_Events_Mapping());
            //User Extend
            modelBuilder.Configurations.Add(new OtherInformation_Mapping());

            //ELMAH
            modelBuilder.Configurations.Add(new ELMAH_Error_Mapping());

            //Site
            modelBuilder.Configurations.Add(new Area_Mapping());
            modelBuilder.Configurations.Add(new City_Mapping());
            modelBuilder.Configurations.Add(new Channel_Mapping());
            modelBuilder.Configurations.Add(new ChannelList_Mapping());
            modelBuilder.Configurations.Add(new ChannelListDetail_Mapping());
        }

        public DbSet<Applications> Applications { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Paths> Paths { get; set; }
        public DbSet<PersonalizationAllUsers> PersonalizationAllUsers { get; set; }
        public DbSet<PersonalizationPerUser> PersonalizationPerUsers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SchemaVersions> SchemaVersions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<WebEvent_Events> WebEvent_Events { get; set; }

        //User      -Extend not MemberShip
        public DbSet<OtherInformation> OtherInformations { get; set; }
        //ELMAH
        public DbSet<ELMAH_Error> ELMAHErrors { get; set; }


        //Site
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelList> ChannelLists { get; set; }


        //
        public DbSet<GoodsCondition> GoodsConditions { get; set; }
    }
}
