using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Domain.Account
{
    public class AccountInitializer :CreateDatabaseIfNotExists<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            base.Seed(context);
        }
    }
}
