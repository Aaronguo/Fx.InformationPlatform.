//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Domain.FxSite.Mapping
{
    #pragma warning disable 1573
    using System.Data.Entity.ModelConfiguration;
    using Fx.Entity.FxSite;
    
    internal partial class GoodsConditions_Mapping : EntityTypeConfiguration<GoodsCondition>
    {
        public GoodsConditions_Mapping()
        {                        
              this.HasKey(t => t.GoodsConditionId);
              this.ToTable("GoodsCondition", "Site");
              this.Property(t => t.GoodsConditionId).HasColumnName("GoodsConditionId");
              this.Property(t => t.GoodsConditionName).HasColumnName("GoodsConditionName");
              this.Property(t => t.Description).HasColumnName("Description");
              this.Property(t => t.Sorted).HasColumnName("Sorted");
              this.Property(t => t.IsHasMessage).HasColumnName("IsHasMessage");
              this.Property(t => t.PlaceHolder).HasColumnName("PlaceHolder");
         }
    }
}
