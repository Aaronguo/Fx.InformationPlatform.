//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Entity.MemberShip
{

    using System;
    using System.Collections.Generic;

    public partial class Applications
    {
        public Applications()
        {
            this.Membership = new HashSet<Membership>();
            this.Paths = new HashSet<Paths>();
            this.Roles = new HashSet<Roles>();
            this.Users = new HashSet<Users>();
        }

        public string ApplicationName { get; set; }
        public string LoweredApplicationName { get; set; }
        public System.Guid ApplicationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Membership> Membership { get; set; }
        public virtual ICollection<Paths> Paths { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
