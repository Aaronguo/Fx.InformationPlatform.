using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    public class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sorted { get; set; }
    }
}
