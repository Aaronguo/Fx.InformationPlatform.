using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 专用于首页获取TopShow数据相关接口
    /// </summary>
    public interface IHomeTopShow
    {
        /// <summary>
        /// 用于首页的Topshow展示 仅仅具有一些重要的基础信息
        /// </summary>
        /// <returns></returns>
        List<Fx.Entity.FxCar.CarTransferInfo> GetHomeCarTopShow();

        List<Fx.Entity.FxGoods.GoodsTransferInfo> GetHomeGoodsTopShow();

        List<Fx.Entity.FxHouse.HouseTransferInfo> GetHomeHouseTopShow();
    }
}
