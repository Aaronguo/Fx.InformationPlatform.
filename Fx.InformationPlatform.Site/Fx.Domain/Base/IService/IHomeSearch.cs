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

        List<T> SearchHottestForHome(int count);

        List<T> SearchTopshowForHome(int count);
    }
}
