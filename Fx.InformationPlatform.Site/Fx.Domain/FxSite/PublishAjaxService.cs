using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxSite.IService;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    /// <summary>
    /// 发布信息Ajax服务
    /// </summary>
    public class PublishAjaxService : BaseIService<SiteContent>, IPageAjax, IDisposable
    {
        public PublishAjaxService()
        {
            this.content = new SiteContent();
        }

        public List<Entity.FxSite.Area> GetAreas()
        {
            return content.Areas.OrderBy(r => r.Sorted).ToList();
        }

        public List<Entity.FxSite.City> GetCitys(int AreaId)
        {
            return content.Cities.Where(r => r.AreaID == AreaId).OrderBy(r => r.Sorted).ToList();
        }

        public List<Entity.FxSite.GoodsCondition> GoodsConditions()
        {
            return content.GoodsConditions.OrderBy(r => r.Sorted).ToList();
        }
    }
}
