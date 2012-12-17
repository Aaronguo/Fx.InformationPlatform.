using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate.IService
{
    public interface IPrivateMessage
    {
        void AddPrivateMessage(PrivateMessage message);

        void RemovePrivateMessage(PrivateMessage message);

        PrivateMessage GetById(int id);

        List<PrivateMessage> GetByUser(string user);
    }
}
