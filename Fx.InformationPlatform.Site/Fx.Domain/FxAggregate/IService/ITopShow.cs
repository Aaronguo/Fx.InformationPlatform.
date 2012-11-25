using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate.IService
{
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
    }
}
