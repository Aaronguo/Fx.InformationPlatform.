using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxAggregate
{
    /// <summary>
    /// 我的收藏  当帖子被删除的时候 此信息也要被删除
    /// </summary>
    public class Favorite
    {
        public int FavoriteId { get; set; }

        public int ChannelCatagroy { get; set; }

        public int InfoId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserAccount { get; set; }

        public Favorite()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
