using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxBrower
{
    public class Brower
    {
        public int BrowerId { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public string Platform { get; set; }

        public string ECMAScriptVersion { get; set; }

        public bool IsMobileDevice { get; set; }

        public string UserAgentDetails { get; set; }

        public string Other { get; set; }

        public string SessionID { get; set; }

        public DateTime CreatedTime { get; set; }

        public Brower()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
