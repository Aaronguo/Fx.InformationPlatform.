using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService
{
    public interface ITransferGoods
    {
        GoodsTransferInfo Get(int Id);

        bool SaveTransferGoods(GoodsTransferInfo goods);
    }
}
