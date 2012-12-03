using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.Base.IService;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.Search
{
    public class GoodsTransferSearchService : ISiteSearch<GoodsTransferInfo>, IGoodsSearch<GoodsTransferInfo>, IHomeSearch<GoodsTransferInfo>
    {
        public List<GoodsTransferInfo> SearchByKey(string key, int page, int take = 20)
        {
            using (var context = new FxGoodsContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return context.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderByDescending(r => r.CreatedTime)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                }
                else
                {
                    return context.GoodsTransferInfos
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
        public List<GoodsTransferInfo> SearchByPrice(int page, bool asc = true, string key = "", int take = 20)
        {
            using (var context = new FxGoodsContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                    .OrderBy(r => r.Price)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                    }
                    else
                    {
                        return context.GoodsTransferInfos
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
                        return context.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                    .OrderBy(r => r.Price)
                                    .Skip(page * take)
                                    .Take(take).ToList();
                    }
                    else
                    {
                        return context.GoodsTransferInfos
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
        public List<GoodsTransferInfo> SearchByDate(int page, bool asc = false, string key = "", int take = 20)
        {
            using (var context = new FxGoodsContext())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (asc)
                    {
                        return context.GoodsTransferInfos
                                        .Include(r => r.Pictures)
                                        .Where(r => r.PublishTitle.Contains(key) && r.IsPublish == true)
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * take)
                                        .Take(take).ToList();
                    }
                    else
                    {
                        return context.GoodsTransferInfos
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
                        return context.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                        .OrderBy(r => r.CreatedTime)
                                        .Skip(page * take)
                                        .Take(take).ToList();
                    }
                    else
                    {
                        return context.GoodsTransferInfos
                                    .Include(r => r.Pictures)
                                    .Where(r => r.IsPublish == true)
                                     .OrderByDescending(r => r.CreatedTime)
                                     .Skip(page * take)
                                     .Take(take).ToList();
                    }
                }
            }
        }

        /// <summary>
        /// 只有按价格交换或按物品交换其中一个勾中后才使用此方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="asc"></param>
        /// <param name="key"></param>
        /// <param name="byPrice"></param>
        /// <param name="byGoods"></param>
        /// <returns></returns>
        //public List<GoodsTransferInfo> SearchByChanges(int page, bool byPrice, bool byGoods, bool asc = false, string key = "")
        //{
        //    using (var context = new FxGoodsContext())
        //    {
        //        if (!string.IsNullOrWhiteSpace(key))
        //        {
        //            if (byPrice)
        //            {
        //                if (asc)
        //                {
        //                    return context.GoodsTransferInfos
        //                               .Where(r => r.PublishTitle.Contains(key) && r.IsChange == false && r.IsPublish == true)
        //                               .OrderBy(r => r.CreatedTime)
        //                               .Skip(page * 20)
        //                               .Take(20).ToList();
        //                }
        //                else
        //                {
        //                    return context.GoodsTransferInfos
        //                               .Where(r => r.PublishTitle.Contains(key) && r.IsChange == false && r.IsPublish == true)
        //                               .OrderByDescending(r => r.CreatedTime)
        //                               .Skip(page * 20)
        //                               .Take(20).ToList();
        //                }
        //            }
        //            else
        //            {
        //                if (asc)
        //                {
        //                    return context.GoodsTransferInfos
        //                                   .Where(r => r.PublishTitle.Contains(key) && r.IsChange == true && r.IsPublish == true)
        //                                   .OrderBy(r => r.CreatedTime)
        //                                   .Skip(page * 20)
        //                                   .Take(20).ToList();
        //                }
        //                else
        //                {
        //                    return context.GoodsTransferInfos
        //                                   .Where(r => r.PublishTitle.Contains(key) && r.IsChange == true && r.IsPublish == true)
        //                                   .OrderByDescending(r => r.CreatedTime)
        //                                   .Skip(page * 20)
        //                                   .Take(20).ToList();
        //                }
        //            }
        //        }
        //        else
        //        {

        //            if (byPrice)
        //            {
        //                if (asc)
        //                {
        //                    return context.GoodsTransferInfos
        //                                   .Where(r => r.IsChange == false && r.IsPublish == true)
        //                                   .OrderBy(r => r.CreatedTime)
        //                                   .Skip(page * 20)
        //                                   .Take(20).ToList();
        //                }
        //                else
        //                {
        //                    return context.GoodsTransferInfos
        //                                   .Where(r => r.IsChange == false && r.IsPublish == true)
        //                                   .OrderByDescending(r => r.CreatedTime)
        //                                   .Skip(page * 20)
        //                                   .Take(20).ToList();
        //                }

        //            }
        //            else
        //            {
        //                if (asc)
        //                {

        //                    return context.GoodsTransferInfos.Where(r => r.IsPublish == true)
        //                                   .Where(r => r.IsChange == true)
        //                                   .OrderBy(r => r.CreatedTime)
        //                                   .Skip(page * 20)
        //                                   .Take(20).ToList();
        //                }
        //                else
        //                {

        //                    return context.GoodsTransferInfos.Where(r => r.IsPublish == true)
        //                                   .Where(r => r.IsChange == true)
        //                                   .OrderByDescending(r => r.CreatedTime)
        //                                   .Skip(page * 20)
        //                                   .Take(20).ToList();
        //                }
        //            }
        //        }
        //    }
        //}

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
    }
}
