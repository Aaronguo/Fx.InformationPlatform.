using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxSite.IService;

namespace Fx.Domain.FxSite
{
    /// <summary>
    /// 发布信息Ajax服务
    /// </summary>
    public class PublishAjaxService : IPageAjax, IDisposable
    {
        SiteContent content = new SiteContent();
        private bool isDispose = false;

        public List<Entity.FxSite.Area> GetAreas()
        {
            return content.Areas.OrderBy(r => r.Sorted).ToList();
        }

        public List<Entity.FxSite.City> GetCitys(int AreaId)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            if (!isDispose)
            {
                content.Dispose();
                isDispose = true;
            }
        }
    }
}
