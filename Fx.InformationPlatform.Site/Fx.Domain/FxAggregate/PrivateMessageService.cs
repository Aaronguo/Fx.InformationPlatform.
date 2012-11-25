using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate
{
    public class PrivateMessageService : IPrivateMessage
    {
        public void AddPrivateMessage(PrivateMessage message)
        {
            using (var content = new FxAggregateContext())
            {
                content.PrivateMessages.Add(message);
                content.SaveChanges();
            }
        }

        public void RemovePrivateMessage(PrivateMessage message)
        {
            using (var content = new FxAggregateContext())
            {
                var entity = content.PrivateMessages
                    .Where(r => r.PrivateMessageId == message.PrivateMessageId).FirstOrDefault();
                if (entity != null)
                {
                    content.PrivateMessages.Remove(entity);
                    content.SaveChanges();
                }
            }
        }
    }
}
