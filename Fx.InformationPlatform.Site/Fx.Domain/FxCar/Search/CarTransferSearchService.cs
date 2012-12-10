using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base;
using Fx.Domain.Base.IService;
using Fx.Entity.FxCar;
using Fx.Infrastructure.Data;

namespace Fx.Domain.FxCar.Search
{
    public class CarTransferSearchService : CommonSearch, ISiteSearch<CarTransferInfo>, IHomeSearch<CarTransferInfo>, ICarSearch<CarTransferInfo>
    {
        public List<CarTransferInfo> SearchByKey(string key, int area = 0, int city = 0,
            int page = 0, int take = 10, int clc = 0)
        {

            int start = 1 + page * 10;
            int end = page * 10 + take;
            var where = CreateWhereExpress(key, area, city, clc);
            string sql = " SELECT [CarTransferInfoId] FROM " +
                "  ( SELECT ROW_NUMBER() OVER ( ORDER BY [CarTransferInfoId] ) " +
                "    AS RowNumber,[CarTransferInfoId],CreatedTime " +
                "      FROM [FxCar].[Car].[CarTransferInfo] " + where.ToString() + " ) " +
                "  AS A1 WHERE RowNumber BETWEEN " + start + " AND " + end;

            SqlHelper db = new SqlHelper(ConfigurationManager.ConnectionStrings["fx.car-sqlserver"].ToString());
            var dt = db.GetDt(sql);
            var ids = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ids.Add(Convert.ToInt32(dt.Rows[i][0]));
            }
            if (ids.Count > 0)
            {
                using (var context = new FxCarContext())
                {
                    return context.CarTransferInfos
                        .Include(r=>r.Pictures)
                        .Where(r => ids.Contains(r.CarTransferInfoId)).ToList();
                }
            }
            else
            {
                return new List<CarTransferInfo>();
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
