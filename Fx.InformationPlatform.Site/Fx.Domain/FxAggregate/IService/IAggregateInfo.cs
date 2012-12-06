using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity;

namespace Fx.Domain.FxAggregate.IService
{
    public interface IAggregateInfo
    {
        IInfo GetInfoByCatatgroyAndId(int ChannelCatagroy, int infoId);

        bool IsValid(IInfo info);
    }
}
