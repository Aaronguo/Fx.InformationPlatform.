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


        int InfoProcessState { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrorMsg { get; set; }
    }

    public enum ProcessState
    {
        /// <summary>
        /// 待审核
        /// </summary>
        Commit = 0,

        /// <summary>
        /// 认证中
        /// </summary>
        Authorizing = 1,


        /// <summary>
        /// 关键词过滤证过成功
        /// </summary>
        AuthorizeSuccess = 2,
        /// <summary>
        /// 关键词过滤认证失败
        /// </summary>
        AuthorizeFaild = 3,

        /// <summary>
        /// 图片处理中
        /// </summary>
        //PictureProcessing = 4,
        /// <summary>
        /// 图片压缩成功
        /// </summary>
        //PictureProcessdSuccessd = 5,//
        /// <summary>
        /// 图片压缩失败
        /// </summary>
        //PictureProcessdFailed = 6,

        ///为什么移除了图片处理几个过程 因为流程现在就是一起的！！！ 但是最佳模式最好分开
        /// <summary>
        /// 图片CDN处理中
        /// </summary>
        PictrueCdning = 7,
        /// <summary>
        /// 图片CDN成功
        /// </summary>
        PictrueCdnSuccessd = 8,//
        /// <summary>
        /// 图片CDN失败
        /// </summary>
        PictrueCdnFailed = 9,
        /// <summary>
        /// Job完成
        /// </summary>
        JobSuccess = 10,
        /// <summary>
        /// 已发布
        /// </summary>
        Publish = 11,
        /// <summary>
        /// 延长展示时间
        /// </summary>
        Delay = 12,
        /// <summary>
        /// 流程结束  不再进行任何处理
        /// </summary>       
        End = 99,


    }
}


