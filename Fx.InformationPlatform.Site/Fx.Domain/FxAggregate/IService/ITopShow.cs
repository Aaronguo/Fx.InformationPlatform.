using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxAggregate;
using Fx.Entity.FxCar;
using Fx.Entity.FxGoods;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 置顶接口 用于一般性的操作
    /// </summary>
    public interface ITopShow
    {
        /// <summary>
        /// 置顶相关帖子
        /// </summary>
        /// <param name="entity"></param>
        void TopShow(TopShow entity);

        /// <summary>
        /// 是否存在InfoId和ChannelCatagroy相同的置顶信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool IsExist(TopShow entity);


        void TopShowCancel(TopShow entity);

        List<TopShow> GetAllTopShow();

        TopShow GetById(int id);

        
        /// <summary>
        /// 用于具体频道的展示 数据完整性
        /// </summary>
        /// <returns></returns>
        List<CarTransferInfo> GetCarTransferTopShow();

        List<GoodsTransferInfo> GetGoodsTransferTopShow();

        List<HouseTransferInfo> GetHouseTransferTopShow();

        List<CarBuyInfo> GetCarBuyTopShow();

        List<GoodsBuyInfo> GetGoodsBuyTopShow();

        List<HouseBuyInfo> GetHouseBuyTopShow();
    }
}
