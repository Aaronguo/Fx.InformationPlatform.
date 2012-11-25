using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxHouse.IService
{
   public interface IHouseTransferJob
    {
        bool Authorizing(int houseId);

        bool AuthorizeSuccess(int houseId);

        bool AuthorizeFaild(int houseId, string msg);

        //bool PictureProcessdSuccessd(int houseId);

        //bool PictureProcessdFailed(int houseId,string erroMsg);

        bool PictrueCdning(int houseId);

        bool PictrueCdnSuccessd(int houseId);

        bool PictrueCdnFailed(int houseId, string erroMsg);

        bool JobSuccess(int houseId);

        bool Publish(int houseId);

        bool Delay(int houseId);

        bool End(int houseId);

        bool NoDelete(int houseId);
    }
}
