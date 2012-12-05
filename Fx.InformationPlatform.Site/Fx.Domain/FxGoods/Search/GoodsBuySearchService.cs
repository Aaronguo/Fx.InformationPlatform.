using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Fx.Domain.Base.IService;
using Fx.Entity.FxGoods;
using Fx.Domain.Base;
using Fx.Infrastructure.Data;
using System.Configuration;

namespace Fx.Domain.FxGoods.Search
{
    public class GoodsBuySearchService : CommonSearch,ISiteSearch<GoodsBuyInfo>, IGoodsSearch<GoodsBuyInfo>
    {

        public List<GoodsBuyInfo> SearchByKey(string key, int area, int city, int page, int take)
        {
            return SearchByKey(key, area, city, page, take, true, true);
        }

        public List<GoodsBuyInfo> SearchByKey(string key, int area = 0, int city = 0, int page = 0, int take = 10, bool changegoods = true, bool changeprice = true)
        {
            int start = 1 + page * 10;
            int end = page * 10 + take;
            var where = CreateCommonSearch(key, area, city);
            if (!(changegoods && changeprice))
            {
                if (changegoods)
                {
                    where.Append(string.Format(" and IsChange={0} ", 1));                    
                }
                else
                {
                    where.Append(string.Format(" and IsChange={0} ", 0));
                }
            }
            string sql = " SELECT [GoodsBuyInfoId] FROM " +
                "  ( SELECT ROW_NUMBER() OVER ( ORDER BY [GoodsBuyInfoId] ) " +
                "    AS RowNumber,[GoodsBuyInfoId],CreatedTime " +
                "      FROM [FxGoods].[Goods].[GoodsBuyInfo] " + where.ToString() + " ) " +
                "  AS A1 WHERE RowNumber BETWEEN " + start + " AND " + end;

            SqlHelper db = new SqlHelper(ConfigurationManager.ConnectionStrings["fx.goods-sqlserver"].ToString());
            var dt = db.GetDt(sql);
            var ids = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ids.Add(Convert.ToInt32(dt.Rows[i][0]));
            }
            using (var context = new FxGoodsContext())
            {
                return context.GoodsBuyInfos
                   .Include(r => r.Pictures)
                   .Where(r => ids.Contains(r.GoodsBuyInfoId)).ToList();
                //if (!string.IsNullOrWhiteSpace(key))
                //{
                //    if (area == 0 && city == 0)
                //    {

                //        return context.GoodsBuyInfos
                //                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                //                        .OrderByDescending(r => r.CreatedTime)
                //                        .Skip(page * take).Take(take).ToList();
                //    }
                //    else if (area > 0)
                //    {
                //        if (city > 0)
                //        {
                //            return context.GoodsBuyInfos
                //                       .Where(r => r.PublishTitle.Contains(key) &&
                //                           r.AreaId == area &&
                //                           r.CityId == city &&
                //                           r.IsPublish == true)
                //                       .OrderByDescending(r => r.CreatedTime)
                //                       .Skip(page * take).Take(take).ToList();
                //        }
                //        else
                //        {
                //            return context.GoodsBuyInfos
                //                       .Where(r => r.PublishTitle.Contains(key) &&
                //                           r.AreaId == area &&
                //                           r.IsPublish == true)
                //                       .OrderByDescending(r => r.CreatedTime)
                //                       .Skip(page * take).Take(take).ToList();
                //        }

                //    }
                //    else
                //    {
                //        return context.GoodsBuyInfos
                //                      .Where(r => r.PublishTitle.Contains(key) &&
                //                          r.IsPublish == true)
                //                      .OrderByDescending(r => r.CreatedTime)
                //                      .Skip(page * take).Take(take).ToList();
                //    }

                //}
                //else
                //{
                //    return context.GoodsBuyInfos
                //                    .Where(r => r.IsPublish == true)
                //                    .OrderByDescending(r => r.CreatedTime)
                //                    .Skip(page * take)
                //                    .Take(take).ToList();
                //}
            }
        }

        //public List<GoodsBuyInfo> SearchWhenChangeGoods(int page = 0, int take = 20)
        //{
        //    using (var context = new FxGoodsContext())
        //    {
        //        return context.GoodsBuyInfos
        //            .Include(r => r.Pictures)
        //            .Where(r => r.IsPublish == true && r.IsChange == true)
        //            .OrderByDescending(r => r.CreatedTime)
        //            .Skip(page * take)
        //            .Take(take).ToList();
        //    }
        //}

        //public List<GoodsBuyInfo> SearchWhenPrice(int page = 0, int take = 20)
        //{
        //    using (var context = new FxGoodsContext())
        //    {
        //        return context.GoodsBuyInfos
        //            .Include(r => r.Pictures)
        //            .Where(r => r.IsPublish == true && r.IsChange == false)
        //            .OrderByDescending(r => r.CreatedTime)
        //            .Skip(page * take)
        //            .Take(take).ToList();
        //    }
        //}


        public List<GoodsBuyInfo> SearchByCatagroy(Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take)
        {
            using (var context = new FxGoodsContext())
            {
                return context.GoodsBuyInfos
                    .Include(r => r.Pictures)
                    .Where(r => r.IsPublish == true && r.CatagroyId == (int)catagroy)
                    .OrderByDescending(r => r.CreatedTime)
                    .Skip(page * take)
                    .Take(take).ToList();
            }
        }


        private IQueryable<GoodsBuyInfo> CreateWhereExpress(IQueryable<GoodsBuyInfo> list, string key, int area, int city, bool changegoods, bool changeprice)
        {
            IQueryable<GoodsBuyInfo> query = list.Include(r=>r.Pictures);
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
