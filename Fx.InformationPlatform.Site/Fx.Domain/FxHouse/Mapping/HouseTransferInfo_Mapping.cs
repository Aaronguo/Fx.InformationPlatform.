//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Domain.FxHouse.Mapping
{
    #pragma warning disable 1573
    using System.Data.Entity.ModelConfiguration;
    using Fx.Entity.FxHouse;
    
    internal partial class HouseTransferInfo_Mapping : EntityTypeConfiguration<HouseTransferInfo>
    {
        public HouseTransferInfo_Mapping()
        {                        
              this.HasKey(t => t.HouseTransferInfoId);        
              this.ToTable("HouseTransferInfo", "House");
              this.Property(t => t.HouseTransferInfoId).HasColumnName("HouseTransferInfoId");
              this.Property(t => t.PostCode).HasColumnName("PostCode").HasMaxLength(32);
              this.Property(t => t.RoadName).HasColumnName("RoadName").HasMaxLength(128);
              this.Property(t => t.PublishTitle).HasColumnName("PublishTitle").HasMaxLength(128);
              this.Property(t => t.CatagroyId).HasColumnName("CatagroyId");
              this.Property(t => t.Price).HasColumnName("Price");
              this.Property(t => t.AreaId).HasColumnName("AreaId");
              this.Property(t => t.CityId).HasColumnName("CityId");
              this.Property(t => t.Bill).HasColumnName("Bill");
              this.Property(t => t.HasFurniture).HasColumnName("HasFurniture");
              this.Property(t => t.RoomNumber).HasColumnName("RoomNumber");
              this.Property(t => t.PublishUserEmail).HasColumnName("PublishUserEmail").HasMaxLength(128);
              this.Property(t => t.Mark).HasColumnName("Mark").HasMaxLength(256);
              this.Property(t => t.Controller).HasColumnName("Controller").HasMaxLength(32);
              this.Property(t => t.Action).HasColumnName("Action").HasMaxLength(32);
              this.Property(t => t.UserAccount).HasColumnName("UserAccount").HasMaxLength(128);
              this.Property(t => t.CreatedTime).HasColumnName("CreatedTime");
              this.Property(t => t.IsDelete).HasColumnName("IsDelete");
              this.Property(t => t.IsPublish).HasColumnName("IsPublish");
              this.Property(t => t.InfoProcessState).HasColumnName("InfoProcessState");
              this.Property(t => t.ErrorMsg).HasColumnName("ErrorMsg").HasMaxLength(256);

              this.HasMany(r => r.Pictures).WithRequired().WillCascadeOnDelete(true);
              this.HasMany(r => r.Logs).WithRequired().WillCascadeOnDelete(true);
         }
    }
}
