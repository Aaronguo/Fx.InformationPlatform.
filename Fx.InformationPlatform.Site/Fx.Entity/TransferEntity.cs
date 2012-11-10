using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxGoods
{
    public class TransferEntity
    {
        public TransferEntity()
        {
            this.CreatedTime = DateTime.Now;
        }

        /// <summary>
        /// 发布者接收信息邮箱
        /// </summary>
        public string PublishUserEmail { get; set; }

        /// <summary>
        /// 发布标题 
        /// </summary>
        public string PublishTitle { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 二级分类Id
        /// </summary>
        //public int ChannelListId { get; set; }

        public string Controller { get; set; }

        /// <summary>
        /// 三级分类Id
        /// </summary>
        //public int ChannelListDetailId { get; set; }

        public string Action { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 发布此信息用户的帐号 这里是发布者的Email 因为使用邮箱作为帐号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
