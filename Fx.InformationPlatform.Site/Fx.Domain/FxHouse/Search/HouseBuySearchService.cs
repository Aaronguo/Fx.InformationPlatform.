using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Fx.Domain.Base;
using Fx.Domain.Base.IService;
using Fx.Entity.FxHouse;
using Fx.Infrastructure.Data;

namespace Fx.Domain.FxHouse.Search
{
    public class HouseBuySearchService : CommonSearch, ISiteSearch<HouseBuyInfo>, IHouseSearch<HouseBuyInfo>
    {
        public List<HouseBuyInfo> SearchByKey(string key, int area = 0, 
            int city = 0, int page = 0, 
            int take = 10,int clc=0)
        {
            int start = 1 + page * 10;
            int end = page * 10 + take;
            var where = CreateWhereExpress(key, area, city, clc);
            string sql = " SELECT [HouseBuyInfoId] FROM " +
                "  ( SELECT ROW_NUMBER() OVER ( ORDER BY [HouseBuyInfoId] ) " +
                "    AS RowNumber,[HouseBuyInfoId],CreatedTime " +
                "      FROM [FxHouse].[House].[HouseBuyInfo] " + where.ToString() + " ) " +
                "  AS A1 WHERE RowNumber BETWEEN " + start + " AND " + end;

            SqlHelper db = new SqlHelper(ConfigurationManager.ConnectionStrings["fx.house-sqlserver"].ToString());
            var dt = db.GetDt(sql);
            var ids = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ids.Add(Convert.ToInt32(dt.Rows[i][0]));
            }
            if (ids.Count > 0)
            {
                using (var context = new FxHouseContext())
                {
                    return context.HouseBuyInfos
                        .Where(r => ids.Contains(r.HouseBuyInfoId)).ToList();
                }
            }
            else
            {
                return new List<HouseBuyInfo>();
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

        private StringBuilder CreateWhereExpress(string key, int area,
            int city, int clc)
        {
            var sb = CreateCommonSearch(key, area, city);
            if (clc != 0)
            {
                sb.Append(" and CatagroyId=" + clc);
            }
            return sb;
        }
    }
}
