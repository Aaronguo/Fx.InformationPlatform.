using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.Base.IService;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.Search
{
    public class CarBuySearchService : ISiteSearch<CarBuyInfo>
    {
        public List<CarBuyInfo> SearchByKey(string key, int page)
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return context.CarBuyInfos
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * 20).Take(20).ToList();
                }
                else
                {
                    return context.CarBuyInfos.Where(r=>r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
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
        public List<CarBuyInfo> SearchByPrice(int page, bool asc = true, string key = "")
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.CarBuyInfos.Where(r=>r.IsPublish == true)
                                    .OrderBy(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                    else
                    {
                        return context.CarBuyInfos.Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.CarBuyInfos
                                    .Where(r => r.PublishTitle.Contains(key)&& r.IsPublish==true)
                                    .OrderBy(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                    else
                    {
                        return context.CarBuyInfos
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
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
        public List<CarBuyInfo> SearchByDate(int page, bool asc, string key)
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.CarBuyInfos
                                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                       .OrderBy(r => r.CreatedTime)
                                       .Skip(page * 20).Take(20).ToList();
                    }
                    else
                    {
                        return context.CarBuyInfos
                                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                        .OrderByDescending(r => r.CreatedTime)
                                        .Skip(page * 20).Take(20).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.CarBuyInfos.Where(r=>r.IsPublish==true)
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * 20).Take(20).ToList();
                    }
                    else
                    {
                        return context.CarBuyInfos.Where(r => r.IsPublish == true)
                                        .OrderByDescending(r => r.CreatedTime)
                                        .Skip(page * 20).Take(20).ToList();
                    }
                }
            }
        }
    }
}
