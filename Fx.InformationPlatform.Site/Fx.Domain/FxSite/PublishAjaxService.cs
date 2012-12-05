using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Fx.Domain.FxSite.IService;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    /// <summary>
    /// 发布信息Ajax服务
    /// </summary>
    public class PublishAjaxService : IPageAjax
    {
        public List<Entity.FxSite.Area> GetAreas()
        {
            using (var content = new SiteContext())
            {
                return content.Areas.OrderBy(r => r.Sorted).ToList();
            }
        }

        public List<Entity.FxSite.City> GetCitys(int AreaId)
        {
            using (var content = new SiteContext())
            {
                return content.Cities.Where(r => r.AreaID == AreaId).OrderBy(r => r.Sorted).ToList();
            }
        }

        public List<Entity.FxSite.GoodsCondition> GoodsConditions()
        {
            using (var content = new SiteContext())
            {
                return content.GoodsConditions.OrderBy(r => r.Sorted).ToList();
            }
        }


        public List<Entity.FxSite.Area> GetAreaDomain()
        {
            using (var content = new SiteContext())
            {
                return content.Areas.Include(r => r.Cities).ToList();
            }
        }
    }
}
