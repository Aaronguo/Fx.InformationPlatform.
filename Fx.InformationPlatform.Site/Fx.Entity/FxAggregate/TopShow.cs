using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxAggregate
{
    public class TopShow
    {
        public int TopShowId { get; set; }

        public int ChannelCatagroy { get; set; }

        public int InfoId { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// 图片 暂时不用
        /// </summary>
        public string HeadPicture { get; set; }

        public int Price { get; set; }

        public DateTime CreatedTime { get; set; }

        public TopShow()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
