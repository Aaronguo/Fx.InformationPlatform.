using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base.IService
{
    public interface IGoodsSearch<T> where T : class
    {
        /// <summary>
        /// 依据交换方式进行查询，辅以关键字查询
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="asc">是否升序</param>
        /// <param name="key">关键字</param>
        /// <param name="byPrice">是否根据价格交换查询 和以物换物条件互斥</param>
        /// <param name="byGoods">是否根据以物换物查询</param>
        /// <returns></returns>
        //List<T> SearchByChanges(int page, bool byPrice, bool byGoods, bool asc, string key);



        /// <summary>
        /// 查找只换物的
        /// </summary>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        List<T> SearchWhenChangeGoods(int page, int take);

        /// <summary>
        /// 查找只现金交易的
        /// </summary>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        List<T> SearchWhenPrice(int page, int take);


        List<T> SearchByCatagroy(Fx.Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take);
    }
}
