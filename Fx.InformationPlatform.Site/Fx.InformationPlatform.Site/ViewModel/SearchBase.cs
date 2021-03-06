﻿using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Fx.Domain.FxSite.IService;
using Fx.Entity.FxSite;
using Fx.Infrastructure.Caching;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class SearchBase
    {
        public SiteCache siteCache;
        public SearchBase()
        {
            this.siteCache = System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();            
        }

        public List<Fx.Entity.FxSite.Area> Areas
        {
            get
            {
                return siteCache.GetArea();
            }
        }

        public string Ad { get; set; }

        public string Action { get; set; }

        public string Key { get; set; }

        public int AreaId { get; set; }

        public int CityId { get; set; }

        public int CurrentIndex { get; set; }

        public int Clc { get; set; }

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
