using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fx.InformationPlatform.Site.Tests.Site
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Fx.Domain.SiteContext site = new Domain.SiteContext();
            try
            {
                var entity = site.Memberships.Where(r => r.Email == "117822597").FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
