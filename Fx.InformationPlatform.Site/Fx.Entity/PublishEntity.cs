using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxGoods
{
    public class Publish
    {
        public Publish()
        {
            this.CreatedTime = DateTime.Now;
        }

        public string PublishUserEmail { get; set; }

        /// <summary>
        /// 发布标题 
        /// </summary>
        public string PublishTitle { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        public string Mark { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        //public virtual ICollection<PublishImage> PublishImages { get; set; }
    }
}
