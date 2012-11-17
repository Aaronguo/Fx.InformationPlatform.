using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxCar.IService
{
    public interface ICarTransferJob
    {
        bool Authorizing(int carId);

        bool AuthorizeSuccess(int carId);

        bool AuthorizeFaild(int carId, string msg);

        //bool PictureProcessdSuccessd(int carId);

        //bool PictureProcessdFailed(int carId,string erroMsg);

        bool PictrueCdning(int carId);

        bool PictrueCdnSuccessd(int carId);

        bool PictrueCdnFailed(int carId, string erroMsg);

        bool JobSuccess(int carId);

        bool Publish(int carId);

        bool Delay(int carId);

        bool End(int carId);
    }
}
