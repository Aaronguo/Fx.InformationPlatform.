using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base.IService;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.Search
{
    public class CarTransferSearchService : ISiteSearch<CarTransferInfo>, IHomeSearch<CarTransferInfo>, ICarSearch<CarTransferInfo> 
    {
        public List<CarTransferInfo> SearchByKey(string key, int page, int take = 20)
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return context.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                }
                else
                {
                    return context.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
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
        public List<CarTransferInfo> SearchByPrice(int page, bool asc = true, string key = "", int take = 20)
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderBy(r => r.Price)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                    }
                    else
                    {
                        return context.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.Price)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderBy(r => r.Price)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                    }
                    else
                    {
                        return context.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderByDescending(r => r.Price)
                                    .Skip(page * take)
                                    .Take(take).ToList();
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
        public List<CarTransferInfo> SearchByDate(int page, bool asc, string key, int take = 20)
        {
            using (var context = new FxCarContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.CarTransferInfos
                                        .Include(r => r.Pictures)
                                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * take)
                                        .Take(take).ToList();
                    }
                    else
                    {
                        return context.CarTransferInfos
                                        .Include(r => r.Pictures)
                                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                        .OrderByDescending(r => r.CreatedTime)
                                        .Skip(page * take)
                                        .Take(take).ToList();
                    }
                }
                else
                {
                    if (asc)
                    {
                        return context.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderBy(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                    }
                    else
                    {
                        return context.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                    }
                }
            }
        }

        public List<CarTransferInfo> SearchLatestForHome(int count)
        {
            using (var content = new FxCarContext())
            {
                return content.CarTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Take(count).ToList();
            }
        }

        public List<CarTransferInfo> SearchHottestForHome(int count)
        {
            throw new NotImplementedException();
        }

        public List<CarTransferInfo> SearchByCatagroy(Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take)
        {
            using (var context = new FxCarContext())
            {
                return context.CarTransferInfos
                    .Include(r => r.Pictures)
                    .Where(r => r.IsPublish == true && r.CatagroyId == (int)catagroy)
                    .OrderByDescending(r => r.CreatedTime)
                    .Skip(page * take)
                    .Take(take).ToList();
            }
        }
    }
}
