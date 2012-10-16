using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity.MemberShip;

namespace Fx.Domain.Account.Mapping.Other
{
    public class OtherInformation_Mapping : EntityTypeConfiguration<OtherInformation>
    {
        public OtherInformation_Mapping()
        {
            this.HasKey(r => r.OtherInformationId);
            this.ToTable("OtherInformation");
            this.Property(r => r.QQ).HasMaxLength(20);
            this.Property(r => r.Mobile).HasMaxLength(20);
        }
    }
}
