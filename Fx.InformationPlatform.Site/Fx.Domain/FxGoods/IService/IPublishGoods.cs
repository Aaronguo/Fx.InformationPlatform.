using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService
{
   public interface IPublishGoods
    {
        CarPublishInfo Get(string Email);
    }
}
