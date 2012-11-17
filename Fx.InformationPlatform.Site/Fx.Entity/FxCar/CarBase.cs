using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxCar
{
    public class CarBase : IInfo
    {
        public CarBase()
        {
            this.CreatedTime = DateTime.Now;
            this.IsDelete = false;
            this.IsPublish = false;
            this.InfoProcessState = (int)ProcessState.Commit;
        }

        /// <summary>
        /// 发布标题 
        /// </summary>
        public string PublishTitle { get; set; }

        /// <summary>
        /// 物品类别
        /// </summary>
        public virtual int CatagroyId { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 汽车生产年份
        /// </summary>
        public int CarYear { get; set; }

        /// <summary>
        /// 汽车已行驶里程数
        /// </summary>
        public int CarMileage { get; set; }

        /// <summary>
        /// 发布者接收信息邮箱
        /// </summary>
        public virtual string PublishUserEmail { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Mark { get; set; }

        public virtual string Controller { get; set; }


        public virtual string Action { get; set; }


        /// <summary>
        /// 发布此信息用户的帐号 这里是发布者的Email 因为使用邮箱作为帐号
        /// </summary>
        public virtual string UserAccount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        public virtual bool IsDelete { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public virtual bool IsPublish { get; set; }

        public int InfoProcessState { get; set; }

        public string ErrorMsg { get; set; }
    }
}
