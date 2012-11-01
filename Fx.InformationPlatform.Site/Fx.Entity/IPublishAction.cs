using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    public interface IPublishAction
    {
        string TransferController { get; set; }

        string BuyController { get; set; }
    }
}
