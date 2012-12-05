using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base;
using Fx.Domain.Base.IService;
using Fx.Entity.FxGoods;
using Fx.Infrastructure.Data;
using System.Configuration;

namespace Fx.Domain.FxGoods.Search
{
    public class GoodsTransferSearchService : CommonSearch, ISiteSearch<GoodsTransferInfo>, IGoodsSearch<GoodsTransferInfo>, IHomeSearch<GoodsTransferInfo>
    {

        public List<GoodsTransferInfo> SearchByKey(string key, int area, int city, int page, int take)
        {
            return SearchByKey(key, area, city, page, take, true, true);
        }

        public List<GoodsTransferInfo> SearchByKey(string key, int area = 0, int city = 0, int page = 0, int take = 10, bool changegoods = true, bool changeprice = true)
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
            string sql = " SELECT [GoodsTransferInfoId] FROM " +
                "  ( SELECT ROW_NUMBER() OVER ( ORDER BY [GoodsTransferInfoId] ) " +
                "    AS RowNumber,[GoodsTransferInfoId],CreatedTime " +
                "      FROM [FxGoods].[Goods].[GoodsTransferInfo] " + where.ToString() + " ) " +
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

                //var where = CreateWhereExpress(key, area, city, changegoods, changeprice);

                //var list = context.ObjectContent
                //    .CreateObjectSet<GoodsTransferInfo>("SELECT *  FROM Goods.TransferPicture " + where)
                //    .Include(r => r.Pictures)
                //    .Skip(page * take).Take(take).ToList();


                return context.GoodsTransferInfos
                    .Include(r => r.Pictures)
                    .Where(r => ids.Contains(r.GoodsTransferInfoId)).ToList();


                //return context.GoodsTransferInfos
                //                    .Include(r => r.Pictures)
                //                    .Where(sb.ToString())
                //                    .OrderByDescending(r => r.CreatedTime)
                //                    .Skip(page * take).Take(take).ToList();
                //return CreateWhereExpress(context.GoodsTransferInfos, key, area, city, changegoods, changeprice)
                //                           .OrderByDescending(r => r.CreatedTime)
                //                           .Skip(page * take).Take(take).ToList();

                //if (!string.IsNullOrWhiteSpace(key))
                //{
                //    if (area == 0 && city == 0)
                //    {

                //        return context.GoodsTransferInfos
                //                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                //                        .OrderByDescending(r => r.CreatedTime)
                //                        .Skip(page * take).Take(take).ToList();
                //    }
                //    else if (area > 0)
                //    {
                //        if (city > 0)
                //        {
                //            return context.GoodsTransferInfos
                //                       .Where(r => r.PublishTitle.Contains(key) &&
                //                           r.AreaId == area &&
                //                           r.CityId == city &&
                //                           r.IsPublish == true)
                //                       .OrderByDescending(r => r.CreatedTime)
                //                       .Skip(page * take).Take(take).ToList();
                //        }
                //        else
                //        {
                //            return context.GoodsTransferInfos
                //                       .Where(r => r.PublishTitle.Contains(key) &&
                //                           r.AreaId == area &&
                //                           r.IsPublish == true)
                //                       .OrderByDescending(r => r.CreatedTime)
                //                       .Skip(page * take).Take(take).ToList();
                //        }

                //    }
                //    else
                //    {
                //        return context.GoodsTransferInfos
                //                      .Where(r => r.PublishTitle.Contains(key) &&
                //                          r.IsPublish == true)
                //                      .OrderByDescending(r => r.CreatedTime)
                //                      .Skip(page * take).Take(take).ToList();
                //    }

                //}
                //else
                //{
                //    return context.GoodsTransferInfos
                //                    .Where(r => r.IsPublish == true)
                //                    .OrderByDescending(r => r.CreatedTime)
                //                    .Skip(page * take)
                //                    .Take(take).ToList();
                //}




            }
        }

        public List<GoodsTransferInfo> SearchLatestForHome(int count)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .Include(r => r.Pictures)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Take(count).ToList();
            }
        }

        public List<GoodsTransferInfo> SearchHottestForHome(int count)
        {
            throw new NotImplementedException();
        }

        public List<GoodsTransferInfo> SearchWhenChangeGoods(int page = 0, int take = 20)
        {
            using (var context = new FxGoodsContext())
            {
                return context.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true && r.IsChange == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
            }
        }

        public List<GoodsTransferInfo> SearchWhenPrice(int page = 0, int take = 20)
        {
            using (var context = new FxGoodsContext())
            {
                return context.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true && r.IsChange == false)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
            }
        }




        public List<GoodsTransferInfo> SearchByCatagroy(Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true && r.CatagroyId == (int)catagroy)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
            }
        }

        private StringBuilder CreateWhereExpress(string key, int area, int city, bool changegoods, bool changeprice)
        {
            var sb = CreateCommonSearch(key, area, city);
            if (!(changegoods && changeprice))
            {
                if (changegoods)
                {
                    sb.Append(" and IsChange=1");
                }
                else
                {
                    sb.Append(" and IsChange=0");
                }
            }
            return sb;
        }

    }
}
