using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base;
using Fx.Domain.Base.IService;
using Fx.Entity.FxHouse;
using Fx.Infrastructure.Data;

namespace Fx.Domain.FxHouse.Search
{
    public class HouseTransferSearchService : CommonSearch, ISiteSearch<HouseTransferInfo>, IHomeSearch<HouseTransferInfo>, IHouseSearch<HouseTransferInfo>
    {
        public List<HouseTransferInfo> SearchByKey(string key, int area = 0,
            int city = 0, int page = 0,
            int take = 10, int clc = 0)
        {
            int start = 1 + page * 10;
            int end = page * 10 + take;
            var where = CreateWhereExpress(key, area, city, clc);
            string sql = " SELECT [HouseTransferInfoId] FROM " +
                "  ( SELECT ROW_NUMBER() OVER ( ORDER BY [HouseTransferInfoId] ) " +
                "    AS RowNumber,[HouseTransferInfoId],CreatedTime " +
                "      FROM [FxHouse].[House].[HouseTransferInfo] " + where.ToString() + " ) " +
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
                    return context.HouseTransferInfos
                        .Where(r => ids.Contains(r.HouseTransferInfoId)).ToList();
                }
            }
            else
            {
                return new List<HouseTransferInfo>();
            }
        }

        public List<HouseTransferInfo> SearchLatestForHome(int count)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Take(count).ToList();
            }
        }

        public List<HouseTransferInfo> SearchHottestForHome(int count)
        {
            throw new NotImplementedException();
        }

        public List<HouseTransferInfo> SearchByCatagroy(Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page = 0, int take = 20)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos
                                    .Include(r => r.Pictures)
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
