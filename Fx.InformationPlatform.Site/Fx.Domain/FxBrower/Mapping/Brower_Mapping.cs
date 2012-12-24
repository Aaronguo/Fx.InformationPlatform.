using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Fx.Entity.FxBrower;

namespace Fx.Domain.FxBrower.Mapping
{
    public class Brower_Mapping : EntityTypeConfiguration<Brower>
    {
        public Brower_Mapping()
        {
            this.HasKey(t => t.BrowerId);
            this.ToTable("Brower", "Collect");
            this.Property(t => t.BrowerId).HasColumnName("BrowerId");
            this.Property(t => t.Name).HasColumnName("Name").HasMaxLength(256);
            this.Property(t => t.Version).HasColumnName("Version").HasMaxLength(256);
            this.Property(t => t.Platform).HasColumnName("Platform").HasMaxLength(256);
            this.Property(t => t.ECMAScriptVersion).HasColumnName("ECMAScriptVersion").HasMaxLength(256);
            this.Property(t => t.IsMobileDevice).HasColumnName("IsMobileDevice");
            this.Property(t => t.UserAgentDetails).HasColumnName("UserAgentDetails").HasMaxLength(256);
            this.Property(t => t.Other).HasColumnName("Other").IsUnicode(false);
            this.Property(t => t.SessionID).HasColumnName("SessionID").HasMaxLength(128);
            this.Property(t => t.CreatedTime).HasColumnName("CreatedTime");
        }
    }
}
