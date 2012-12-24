using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxBrower;

namespace Fx.Domain.FxBrower
{
    public class BrowerService
    {
        public void AddBrower(Brower brower)
        {
            using (var context = new Fx.Domain.FxBrower.FxBrowerContext())
            {
                context.Browers.Add(brower);
                context.SaveChanges();
            }
        }


        public bool IsExist(string SessionID)
        {
            using (var context = new Fx.Domain.FxBrower.FxBrowerContext())
            {
                return context.Browers.Where(r => r.SessionID == SessionID).FirstOrDefault() != null;
            }
        }

    }
}
