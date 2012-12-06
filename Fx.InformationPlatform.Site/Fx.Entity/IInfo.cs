using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    /// <summary>
    /// 用于记录所有帖子的一些系统信息 抽象层
    /// </summary>
    public interface IInfo
    {
        /// <summary>
        /// 发布标题 
        /// </summary>
        string PublishTitle { get; set; }

        /// <summary>
        /// 物品类别
        /// </summary>
        int CatagroyId { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        int Price { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        int AreaId { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        int CityId { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        string Mark { get; set; }

        /// <summary>
        /// 发布者接收信息邮箱
        /// </summary>
         string PublishUserEmail { get; set; }


        /// <summary>
        /// 发布此信息用户的帐号 这里是发布者的Email 因为使用邮箱作为帐号
        /// </summary>
        string UserAccount { get; set; }


        string Controller { get; set; }


        string Action { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreatedTime { get; set; }

        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        bool IsDelete { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        bool IsPublish { get; set; }


        int InfoProcessState { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrorMsg { get; set; }
    }   
}


