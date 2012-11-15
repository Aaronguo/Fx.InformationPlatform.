using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.IService
{
    public interface ITransferCar
    {
        CarTransferInfo Get(int Id);

        bool SaveTransferCar(CarTransferInfo car);
    }
}
