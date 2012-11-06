using System;
using System.Collections.Generic;
using System.Linq;
using Fx.Domain.FxSite.IService;
using Fx.Infrastructure;
using Fx.Infrastructure.Caching;

namespace Fx.Domain.FxSite
{
    public class CarService : BaseIService<SiteContext>, ICar, IDisposable
    {
        private readonly string CARKEYYEAR = "Fx.Domain.FxSite.CarService.GetCarShowYear";
        private readonly string CARMILEAGE = "Fx.Domain.FxSite.CarService.CARMILEAGE";
        ICacheManager cachemanager;
        public CarService(ICacheManager cachemanager)
        {
            this.content = new Lazy<SiteContext>(() => new SiteContext());
            this.cachemanager = cachemanager;
        }

        public List<Entity.FxSite.ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName)
        {
            var channelList = content.Value.ChannelLists.Where(
                r => r.BuyController == ControllerName && r.ActionName == ActionName).FirstOrDefault();
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }


        public List<Entity.FxSite.ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName)
        {
            var channelList = content.Value.ChannelLists.Where(
                r => r.TransferController == ControllerName && r.ActionName == ActionName).FirstOrDefault();
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }


        /// <summary>
        /// ????  可以不用缓存 因为Controller做了，暂时保留
        /// 不过后期进行检索较为方便
        /// </summary>
        /// <returns></returns>
        public List<int> GetCarShowYear()
        {
            if (cachemanager.Get(CARKEYYEAR) == null)
            {
                List<int> years = new List<int>();
                int currentyear = DateTime.Now.Year;
                for (int i = 1995; i <= currentyear; i++)
                {
                    years.Add(i);
                }
                cachemanager.Insert(CARKEYYEAR, years, 3600, System.Web.Caching.CacheItemPriority.Default);
            }
            return cachemanager.Get(CARKEYYEAR) as List<int>;
        }


        public Dictionary<int, string> GetCarMileage()
        {
            if (cachemanager.Get(CARMILEAGE) == null)
            {
                var carMileage = new Dictionary<int,string>();
                carMileage.Add(1, "100英里以下");
                carMileage.Add(2, "5000英里以下");
                carMileage.Add(3, "10000英里以下");
                carMileage.Add(4, "20000英里以下");
                carMileage.Add(5, "40000英里以下");
                carMileage.Add(6, "60000英里以下");
                carMileage.Add(7, "80000英里以下");
                carMileage.Add(8, "100000英里以下");
                carMileage.Add(9, "100000英里以上");
                cachemanager.Insert(CARMILEAGE, carMileage, 3600, System.Web.Caching.CacheItemPriority.Default);
            }
            return cachemanager.Get(CARMILEAGE) as Dictionary<int,string>;
        }
    }
}
