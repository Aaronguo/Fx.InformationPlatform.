using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base.IService
{
    public interface IGoodsSearch<T> where T : class
    {
        List<T> SearchByKey(string key, int area, int city, int page, int take, bool changegoods, bool changeprice);

        ///// <summary>
        ///// 查找只换物的
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="take"></param>
        ///// <returns></returns>
        //List<T> SearchWhenChangeGoods(int page, int take);

        ///// <summary>
        ///// 查找只现金交易的
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="take"></param>
        ///// <returns></returns>
        //List<T> SearchWhenPrice(int page, int take);


        List<T> SearchByCatagroy(Fx.Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take);
    }
}
