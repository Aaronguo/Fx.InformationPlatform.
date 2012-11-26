using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fx.InformationPlatform.Site.Tests.Data
{
    [TestClass]
    public class CreateUrl
    {
        [TestMethod]
        public void CreateTransfer()
        {
            Fx.Domain.SiteContext site = new Domain.SiteContext();
            var lists = site.ChannelLists.ToList();
            foreach (var item in lists)
            {
                foreach (var detail in item.ChannelListDetails)
                {
                    Console.WriteLine(string.Format("<span><a href=\"/{0}List/{1}\" target=\"_blank\">{2}</a></span>",
                  item.TransferController, detail.ChannelListDetailId,detail.ChannelListDetailName));
                }

            }
        }


        [TestMethod]
        public void CreateBuy()
        {
            Fx.Domain.SiteContext site = new Domain.SiteContext();
            var lists = site.ChannelLists.ToList();
            foreach (var item in lists)
            {
                foreach (var detail in item.ChannelListDetails)
                {
                    Console.WriteLine(string.Format("<span><a href=\"/{0}List/{1}\" target=\"_blank\">{2}</a></span>",
                  item.BuyController, detail.ChannelListDetailId, detail.ChannelListDetailName));
                }

            }
        }
    }
}
