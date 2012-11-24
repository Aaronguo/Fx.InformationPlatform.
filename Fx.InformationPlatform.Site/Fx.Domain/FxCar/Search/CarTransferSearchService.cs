using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base.IService;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.Search
{
    public class CarTransferSearchService : ISiteSearch<CarTransferInfo>,IHomeSearch<CarTransferInfo>
    {
        public List<CarTransferInfo> SearchByKey(string key, int page)
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return context.CarTransferInfos
                                    .Where(r => r.PublishTitle.Contains(key))
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                }
                else
                {
                    return context.CarTransferInfos
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
        public List<CarTransferInfo> SearchByPrice(int page, bool asc = true, string key = "")
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.CarTransferInfos
                                    .OrderBy(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                    else
                    {
                        return context.CarTransferInfos
                                    .OrderByDescending(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.CarTransferInfos
                                    .Where(r => r.PublishTitle.Contains(key))
                                    .OrderBy(r => r.Price)
                                    .Skip(page * 20)
                                    .Take(20).ToList();
                    }
                    else
                    {
                        return context.CarTransferInfos
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
        public List<CarTransferInfo> SearchByDate(int page, bool asc, string key)
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.CarTransferInfos
                                        .Where(r => r.PublishTitle.Contains(key))
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                    else
                    {
                        return context.CarTransferInfos
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
                        return context.CarTransferInfos
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                    else
                    {
                        return context.CarTransferInfos
                                        .OrderByDescending(r => r.CreatedTime)
                                        .Skip(page * 20)
                                        .Take(20).ToList();
                    }
                }
            }
        }

        public List<CarTransferInfo> SearchLatestForHome(int count)
        {
            using (var content = new FxCarContext())
            {
                return content.CarTransferInfos.Include(r => r.Pictures).OrderByDescending(r => r.CreatedTime).Take(count).ToList();
            }
        }

        public List<CarTransferInfo> SearchHottestForHome(int count)
        {
            throw new NotImplementedException();
        }

        public List<CarTransferInfo> SearchTopshowForHome(int count)
        {
            throw new NotImplementedException();
        }
    }
}
