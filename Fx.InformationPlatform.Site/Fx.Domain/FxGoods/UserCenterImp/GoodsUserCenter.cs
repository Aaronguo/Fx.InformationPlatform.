using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxGoods.IService.UserCenter;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.UserCenterImp
{
    public class GoodsUserCenter : IGoodsUserCenter
    {
        public List<GoodsTransferInfo> GetTransfers(string email)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsTransferInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        public List<GoodsBuyInfo> GetBuys(string email)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsBuyInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }


        public List<GoodsTransferInfo> GetAdminTransfers(int page = 0)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsTransferInfos
                    .OrderByDescending(r => r.GoodsTransferInfoId)
                    //.Include(r => r.UserAccount)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }

        public List<GoodsBuyInfo> GetAdminBuys(int page = 0)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsBuyInfos
                    .OrderByDescending(r => r.GoodsBuyInfoId)
                    //.Include(r => r.UserAccount)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }
    }
}
