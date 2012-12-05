using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.Base.IService;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.Search
{
    public class HouseBuySearchService : ISiteSearch<HouseBuyInfo>, IHouseSearch<HouseBuyInfo>
    {
        public List<HouseBuyInfo> SearchByKey(string key, int area = 0, int city = 0, int page = 0, int take = 10)
        {
            using (var context = new FxHouseContext())
            {
                return CreateWhereExpress(context.HouseBuyInfos, key, area, city)
                                       .OrderByDescending(r => r.CreatedTime)
                                       .Skip(page * take).Take(take).ToList();
                //if (!string.IsNullOrWhiteSpace(key))
                //{
                //    if (area == 0 && city == 0)
                //    {

                //        return context.HouseBuyInfos
                //                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                //                        .OrderByDescending(r => r.CreatedTime)
                //                        .Skip(page * take).Take(take).ToList();
                //    }
                //    else if (area > 0)
                //    {
                //        if (city > 0)
                //        {
                //            return context.HouseBuyInfos
                //                       .Where(r => r.PublishTitle.Contains(key) &&
                //                           r.AreaId == area &&
                //                           r.CityId == city &&
                //                           r.IsPublish == true)
                //                       .OrderByDescending(r => r.CreatedTime)
                //                       .Skip(page * take).Take(take).ToList();
                //        }
                //        else
                //        {
                //            return context.HouseBuyInfos
                //                       .Where(r => r.PublishTitle.Contains(key) &&
                //                           r.AreaId == area &&
                //                           r.IsPublish == true)
                //                       .OrderByDescending(r => r.CreatedTime)
                //                       .Skip(page * take).Take(take).ToList();
                //        }

                //    }
                //    else
                //    {
                //        return context.HouseBuyInfos
                //                      .Where(r => r.PublishTitle.Contains(key) &&
                //                          r.IsPublish == true)
                //                      .OrderByDescending(r => r.CreatedTime)
                //                      .Skip(page * take).Take(take).ToList();
                //    }

                //}
                //else
                //{
                //    return context.HouseBuyInfos
                //                    .Where(r => r.IsPublish == true)
                //                    .OrderByDescending(r => r.CreatedTime)
                //                    .Skip(page * take)
                //                    .Take(take).ToList();
                //}
            }
        }

        public List<HouseBuyInfo> SearchByCatagroy(Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseBuyInfos
                                    .Where(r => r.IsPublish == true && r.CatagroyId == (int)catagroy)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
            }
        }

        private IQueryable<HouseBuyInfo> CreateWhereExpress(IQueryable<HouseBuyInfo> list, string key, int area = 0, int city = 0)
        {
            IQueryable<HouseBuyInfo> query = list;
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
