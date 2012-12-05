using System;
using System.Collections.Generic;
using System.Linq;
using Fx.Infrastructure.Caching;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class SearchBase
    {
        private SiteCache cache = new SiteCache(new Fx.Domain.FxSite.PublishAjaxService());

        public List<Fx.Entity.FxSite.Area> Areas
        {
            get
            {
                return cache.GetArea();
            }
        }

        public string Ad { get; set; }

        public string Action { get; set; }

        public string Key { get; set; }

        public int AreaId { get; set; }

        public int CityId { get; set; }

        public int CurrentIndex { get; set; }

        public int StartIndex
        {
            get
            {
                // 11  1*10+1=11
                // 1  0*10+1=1
                int number = CurrentIndex / 10;
                if (number == 0)
                {
                    return 1;
                }
                return number * 10;
            }
        }

        public int EndIndex
        {
            get
            {
                int number = CurrentIndex / 10;
                return (number + 1) * 10;
            }
        }

        public virtual void CheckModel()
        {

        }
    }
}
