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
        /// 按关键字查询 （标题） 缓存会
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="page">页码</param>
        /// <param name="take">获取数据的数量</param>
        /// <param name="area">地区</param>
        /// <param name="city">城市</param>
        /// <param name="clc">帖子对应的二级或者三级频道Id</param>
        /// <returns></returns>
        List<T> SearchByKey(string key, int area, int city, int page, int take,int clc);
    }
}
