using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    public enum ProcessState
    {
        /// <summary>
        /// 待审核
        /// </summary>
        [Description("待审核")]
        Commit = 0,

        /// <summary>
        /// 认证中
        /// </summary>
        [Description("认证中")]
        Authorizing = 1,


        /// <summary>
        /// 关键词过滤认证成功
        /// </summary>
        [Description("关键词过滤认证成功")]
        AuthorizeSuccess = 2,
        /// <summary>
        /// 关键词过滤认证失败
        /// </summary>
        [Description("关键词过滤认证失败")]
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
        [Description("图片CDN处理中")]
        PictrueCdning = 7,
        /// <summary>
        /// 图片CDN成功
        /// </summary>
        [Description("图片CDN成功")]
        PictrueCdnSuccessd = 8,//
        /// <summary>
        /// 图片CDN失败
        /// </summary>
       [Description("图片CDN失败")]
        PictrueCdnFailed = 9,
        /// <summary>
        /// Job完成
        /// </summary>
        [Description("Job完成")]
        JobSuccess = 10,
        /// <summary>
        /// 已发布
        /// </summary>
        [Description("已发布")]
        Publish = 11,
        /// <summary>
        /// 延长展示时间
        /// </summary>
        [Description("延长展示时间")]
        Delay = 12,
        /// <summary>
        /// 流程结束 交易完成 不再进行任何处理
        /// </summary>
        [Description("交易完成")]
        End = 99,

        [Description("不删除状态【置顶中...】")]
        NoDelete=-1
    }
}
