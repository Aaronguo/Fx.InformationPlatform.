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
        string Controller { get; set; }


        string Action { get; set; }

        /// <summary>
        /// 发布此信息用户的帐号 这里是发布者的Email 因为使用邮箱作为帐号
        /// </summary>
        string UserAccount { get; set; }

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
    }
}
