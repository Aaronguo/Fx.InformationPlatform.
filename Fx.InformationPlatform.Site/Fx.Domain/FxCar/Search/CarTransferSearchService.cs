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
        public List<CarTransferInfo> SearchByKey(string key, int area = 0, int city = 0, int page = 0, int take = 10)
        {
            using (var context = new FxCarContext())
            {
                return CreateWhereExpress(context.CarTransferInfos, key, area, city)
                                       .OrderByDescending(r => r.CreatedTime)
                                       .Skip(page * take).Take(take).ToList();
                //if (!string.IsNullOrWhiteSpace(key))
                //{
                //    if (area == 0 && city == 0)
                //    {

                //        return context.CarTransferInfos
                //                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                //                        .OrderByDescending(r => r.CreatedTime)
                //                        .Skip(page * take).Take(take).ToList();
                //    }
                //    else if (area > 0)
                //    {
                //        if (city > 0)
                //        {
                //            return context.CarTransferInfos
                //                       .Where(r => r.PublishTitle.Contains(key) &&
                //                           r.AreaId == area &&
                //                           r.CityId == city &&
                //                           r.IsPublish == true)
                //                       .OrderByDescending(r => r.CreatedTime)
                //                       .Skip(page * take).Take(take).ToList();
                //        }
                //        else
                //        {
                //            return context.CarTransferInfos
                //                       .Where(r => r.PublishTitle.Contains(key) &&
                //                           r.AreaId == area &&
                //                           r.IsPublish == true)
                //                       .OrderByDescending(r => r.CreatedTime)
                //                       .Skip(page * take).Take(take).ToList();
                //        }

                //    }
                //    else
                //    {
                //        return context.CarTransferInfos
                //                      .Where(r => r.PublishTitle.Contains(key) &&
                //                          r.IsPublish == true)
                //                      .OrderByDescending(r => r.CreatedTime)
                //                      .Skip(page * take).Take(take).ToList();
                //    }

                //}
                //else
                //{
                //    return context.CarTransferInfos
                //                    .Where(r => r.IsPublish == true)
                //                    .OrderByDescending(r => r.CreatedTime)
                //                    .Skip(page * take)
                //                    .Take(take).ToList();
                //}
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

        private IQueryable<CarTransferInfo> CreateWhereExpress(IQueryable<CarTransferInfo> list, string key, int area = 0, int city = 0)
        {
            IQueryable<CarTransferInfo> query = list.Include(r => r.Pictures);
            if (!string.IsNullOrWhiteSpace(key))
            {
                list = list.Where(r => r.PublishTitle.Contains(key));
            }
            if (area > 0)
            {
                list = list.Where(r => r.AreaId == area);
            }
            if (city > 0)
            {
                list = list.Where(r => r.CityId == city);
            }
            return query.Where(r => r.IsPublish == true);
        }
    }
}
