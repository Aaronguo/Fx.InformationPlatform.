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
            //http://localhost:3579/CarTransferSearch/Audi/2
            Fx.Domain.SiteContext site = new Domain.SiteContext();
            var lists = site.ChannelLists.ToList();
            foreach (var item in lists)
            {
                foreach (var detail in item.ChannelListDetails)
                {
                    Console.WriteLine(string.Format("<span><a href=\"/{0}Search/{1}/1\" target=\"_blank\">{2}</a></span>",
                  item.TransferController, detail.ActionName,detail.ChannelListDetailName));
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
                    Console.WriteLine(string.Format("<span><a href=\"/{0}Search/{1}/1\" target=\"_blank\">{2}</a></span>",
                  item.BuyController, detail.ActionName, detail.ChannelListDetailName));
                }

            }
        }
    }
}
