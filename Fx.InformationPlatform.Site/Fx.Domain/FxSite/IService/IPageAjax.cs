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

        /// <summary>
        /// 获取物品信息新旧程度相关信息
        /// </summary>
        /// <returns></returns>
        List<GoodsCondition> GoodsConditions();

        /// <summary>
        /// 获取所有的地区包括其级联城市
        /// </summary>
        /// <returns></returns>
        List<Entity.FxSite.Area> GetAreaDomain();
    }
}
