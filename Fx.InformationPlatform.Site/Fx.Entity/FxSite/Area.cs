using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 地区
    /// </summary>
    public class Area
    {
        public Area()
        {
            this.Cities = new HashSet<City>();
        }

        public int AreaId { get; set; }

        public string AreaName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sorted { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
