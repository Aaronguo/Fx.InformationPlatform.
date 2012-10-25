using System.Collections.Generic;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite.IService
{
    public interface IPageAjax
    {
        /// <summary>
        /// 获取所有的地区 顺序排序
        /// </summary>
        /// <returns></returns>
        List<Area> GetAreas();

        /// <summary>
        /// 获取地区对应的城市 顺序排序
        /// </summary>
        /// <returns></returns>
        List<City> GetCitys(int AreaId);
    }
}
