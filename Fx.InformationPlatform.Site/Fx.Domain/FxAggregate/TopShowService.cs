using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Entity;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate
{
    public class TopShowService : ITopShow
    {
        public void TopShow(TopShow entity)
        {
            if (!IsExist(entity))
            {
                using (var content = new FxAggregateContext())
                {
                    content.TopShows.Add(entity);
                    content.SaveChanges();
                }
            }
        }


        public bool IsExist(TopShow entity)
        {
            using (var content = new FxAggregateContext())
            {
                return content.TopShows
                    .Where(r => r.TopShowId == entity.TopShowId && r.ChannelCatagroy == entity.ChannelCatagroy)
                    .FirstOrDefault() != null;
            }
        }


        /// <summary>
        /// 取消置顶
        /// </summary>
        /// <param name="entity"></param>
        public void TopShowCancel(TopShow entity)
        {
            if (IsExist(entity))
            {
                using (var content = new FxAggregateContext())
                {
                    entity = content.TopShows
                    .Where(r => r.TopShowId == entity.TopShowId && r.ChannelCatagroy == entity.ChannelCatagroy)
                    .FirstOrDefault();
                    if (entity != null)
                    {
                        content.TopShows.Remove(entity);
                        content.SaveChanges();
                    }
                }
            }
        }


        public List<TopShow> GetAllTopShow()
        {
            using (var content = new FxAggregateContext())
            {
                return content.TopShows.ToList();
            }
        }


        public TopShow GetById(int id)
        {
            using (var content = new FxAggregateContext())
            {
                return content.TopShows.Where(r => r.TopShowId == id).FirstOrDefault();
            }
        }
    }
}
