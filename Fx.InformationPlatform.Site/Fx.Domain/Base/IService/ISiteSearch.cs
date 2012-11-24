using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity;

namespace Fx.Domain.Base.IService
{
    //ChannelCatagroy channelCatagroy, 
    /// <summary>
    /// 帖子关键字查询接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISiteSearch<T> where T : class
    {
        /// <summary>
        /// 按关键字查询 （标题）
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        List<T> SearchByKey(string key, int page);


        /// <summary>
        /// 可以根据关键字,按价格排序
        /// </summary>
        /// <param name="page">页码</param>        
        /// <param name="asc">是否升序</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        List<T> SearchByPrice(int page, bool asc, string key);


        /// <summary>
        /// 可以根据关键字,按时间排序
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="asc">是否升序</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        List<T> SearchByDate(int page, bool asc, string key);        
    }
}
