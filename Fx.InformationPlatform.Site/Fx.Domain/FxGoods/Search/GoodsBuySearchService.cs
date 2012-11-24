using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.Base.IService;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.Search
{
    public class GoodsBuySearchService : ISiteSearch<GoodsBuyInfo>, IGoodsSearch<GoodsBuyInfo>
    {
        public List<GoodsBuyInfo> SearchByKey(string key, int page)
        {
            using (var context = new FxGoodsContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return context.GoodsBuyInfos
                                    .Where(r => r.PublishTitle.Contains(key))
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * 20).Take(20).ToList();
                }
                else
                {
                    return context.GoodsBuyInfos
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * 20).Take(20).ToList();
                }
            }
        }

        /// <summary>
        /// 按价格查询 默认价格从低到高
        /// </summary>
        /// <param name="page"></param>
        /// <param name="asc"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<GoodsBuyInfo> SearchByPrice(int page, bool asc = true, string key = "")
        {
            using (var context = new FxGoodsContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.GoodsBuyInfos
                                    .OrderBy(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                    else
                    {
                        return context.GoodsBuyInfos
                                    .OrderByDescending(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.GoodsBuyInfos
                                    .Where(r => r.PublishTitle.Contains(key))
                                    .OrderBy(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                    else
                    {
                        return context.GoodsBuyInfos
                                    .Where(r => r.PublishTitle.Contains(key))
                                    .OrderByDescending(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                }
            }
        }

        /// <summary>
        /// 根据时间排序
        /// </summary>
        /// <param name="key"></param>
        /// <param name="asc"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<GoodsBuyInfo> SearchByDate(int page, bool asc = false, string key = "")
        {
            using (var context = new FxGoodsContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.GoodsBuyInfos
                                        .Where(r => r.PublishTitle.Contains(key))
                                       .OrderBy(r => r.CreatedTime)
                                       .Skip(page * 20)
                                       .Take(20).ToList();
                    }
                    else
                    {
                        return context.GoodsBuyInfos
                                        .Where(r => r.PublishTitle.Contains(key))
                                        .OrderByDescending(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.GoodsBuyInfos
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                    else
                    {
                        return context.GoodsBuyInfos
                                        .OrderByDescending(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                }
            }
        }

        public List<GoodsBuyInfo> SearchByChanges(int page, bool byPrice, bool byGoods, bool asc, string key)
        {
            using (var context = new FxGoodsContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (byPrice)
                    {
                        if (asc)
                        {
                            return context.GoodsBuyInfos
                                       .Where(r => r.PublishTitle.Contains(key) && r.IsChange == false)
                                       .OrderBy(r => r.CreatedTime)
                                       .Skip(page * 20)
                                       .Take(20).ToList();
                        }
                        else
                        {
                            return context.GoodsBuyInfos
                                       .Where(r => r.PublishTitle.Contains(key) && r.IsChange == false)
                                       .OrderByDescending(r => r.CreatedTime)
                                       .Skip(page * 20)
                                       .Take(20).ToList();
                        }
                    }
                    else
                    {
                        if (asc)
                        {
                            return context.GoodsBuyInfos
                                           .Where(r => r.PublishTitle.Contains(key) && r.IsChange == true)
                                           .OrderBy(r => r.CreatedTime)
                                           .Skip(page * 20)
                                           .Take(20).ToList();
                        }
                        else
                        {
                            return context.GoodsBuyInfos
                                          .Where(r => r.PublishTitle.Contains(key) && r.IsChange == true)
                                          .OrderByDescending(r => r.CreatedTime)
                                          .Skip(page * 20)
                                          .Take(20).ToList();
                        }
                    }
                }
                else
                {

                    if (byPrice)
                    {
                        if (asc)
                        {
                            return context.GoodsBuyInfos
                                           .Where(r => r.IsChange == false)
                                           .OrderBy(r => r.CreatedTime)
                                           .Skip(page * 20)
                                           .Take(20).ToList();
                        }
                        else
                        {
                            return context.GoodsBuyInfos
                                           .Where(r => r.IsChange == false)
                                           .OrderByDescending(r => r.CreatedTime)
                                           .Skip(page * 20)
                                           .Take(20).ToList();
                        }

                    }
                    else
                    {
                        if (asc)
                        {

                            return context.GoodsBuyInfos
                                           .Where(r => r.IsChange == true)
                                           .OrderBy(r => r.CreatedTime)
                                           .Skip(page * 20)
                                           .Take(20).ToList();
                        }
                        else
                        {

                            return context.GoodsBuyInfos
                                           .Where(r => r.IsChange == true)
                                           .OrderByDescending(r => r.CreatedTime)
                                           .Skip(page * 20)
                                           .Take(20).ToList();
                        }
                    }
                }
            }
        }
    }
}
