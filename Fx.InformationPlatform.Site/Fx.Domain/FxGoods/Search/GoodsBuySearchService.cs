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
    public class GoodsBuySearchService : CommonSearch, ISiteSearch<GoodsBuyInfo>, IGoodsSearch<GoodsBuyInfo>
    {

        public List<GoodsBuyInfo> SearchByKey(string key, int area, int city, int page, int take, int clc)
        {
            return SearchByKey(key, area, city, page, take, true, true, clc);
        }

        public List<GoodsBuyInfo> SearchByKey(string key, int area = 0,
            int city = 0, int page = 0,
            int take = 10, bool changegoods = true,
            bool changeprice = true, int clc = 0)
        {
            int start = 1 + page * 10;
            int end = page * 10 + take;
            var where = CreateWhereExpress(key, area, city, changegoods, changeprice, clc);
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
            if (ids.Count > 0)
            {
                using (var context = new FxGoodsContext())
                {
                    return context.GoodsBuyInfos
                       .Include(r => r.Pictures)
                       .Where(r => ids.Contains(r.GoodsBuyInfoId)).ToList();
                }
            }
            else
            {
                return new List<GoodsBuyInfo>();
            }
        }

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


        private StringBuilder CreateWhereExpress(string key, int area,
            int city, bool changegoods,
            bool changeprice, int clc)
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
            if (clc != 0)
            {
                //不在去读取数据库 性能第一 后期考虑基础表不在使用创建来得到ID
                if (clc == 1)//数码产品
                {
                    sb.Append(" and CatagroyId >= 1 and CatagroyId<=8");
                }
                else if (clc == 2)//居家用品
                {
                    sb.Append(" and CatagroyId >= 9 and CatagroyId<=17");
                }
                else if (clc == 3)//衣服鞋包
                {
                    sb.Append(" and CatagroyId >= 18 and CatagroyId<=22");
                }
                else if (clc == 4)//文化生活
                {
                    sb.Append(" and CatagroyId >= 23 and CatagroyId<=27");
                }
                else if (clc == 5)//其他
                {
                    sb.Append(" and CatagroyId=28");
                }
            }
            return sb;
        }


    }
}
