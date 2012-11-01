using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService
{
   public interface IPublishGoods
    {
        GoodsTransferInfo Get(string Email);
    }
}
