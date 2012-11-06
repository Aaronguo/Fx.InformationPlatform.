using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService
{
   public interface ITransferGoods
    {
        GoodsTransferInfo Get(string Email);
    }
}
