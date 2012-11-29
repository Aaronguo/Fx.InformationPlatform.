using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base.IService
{
    /// <summary>
    /// 首页的图片检索接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHomeSearch<T> where T : class
    {
        List<T> SearchLatestForHome(int count);

        /// <summary>
        ///  没有实现 取消此功能 later imp
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        //List<T> SearchHottestForHome(int count);

        /// <summary>
        /// 没有实现 由Aggregate实现
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        //List<T> SearchTopshowForHome(int count);
    }
}
