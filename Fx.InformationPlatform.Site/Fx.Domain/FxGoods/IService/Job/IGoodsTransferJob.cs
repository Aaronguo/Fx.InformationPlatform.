using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxGoods.IService
{
    public interface IGoodsTransferJob
    {
        bool Authorizing(int goodsId);

        bool AuthorizeSuccess(int goodsId);

        bool AuthorizeFaild(int goodsId, string msg);

        //bool PictureProcessdSuccessd(int goodsId);

        //bool PictureProcessdFailed(int goodsId,string erroMsg);

        bool PictrueCdning(int goodsId);

        bool PictrueCdnSuccessd(int goodsId);

        bool PictrueCdnFailed(int goodsId, string erroMsg);

        bool JobSuccess(int goodsId);

        bool Publish(int goodsId);

        bool Delay(int goodsId);

        bool End(int goodsId);
    }
}
