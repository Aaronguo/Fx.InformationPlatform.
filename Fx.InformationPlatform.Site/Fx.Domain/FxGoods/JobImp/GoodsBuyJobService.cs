using System;
using System.Linq;
using Fx.Domain.FxGoods.IService;
using Fx.Entity;

namespace Fx.Domain.FxGoods
{
    public class GoodsBuyJobService : IGoodsBuyJob
    {
        public bool Authorizing(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.Authorizing;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Authorizing)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool AuthorizeSuccess(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.AuthorizeSuccess;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool AuthorizeFaild(int goodsId,string msg)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    goods.ErrorMsg = msg;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictureProcessdSuccessd(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Publish(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.Publish;
                    goods.IsPublish = true;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Publish)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Delay(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.Delay;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delay)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool End(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.End;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.End)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }




        public bool PictrueCdning(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.PictrueCdning;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdning)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictrueCdnSuccessd(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.PictrueCdnSuccessd;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnSuccessd)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictrueCdnFailed(int goodsId, string errorMsg)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.PictrueCdnFailed;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnFailed)
                    });
                    context.PictureCdnErrors.Add(new PictureCdnError()
                    {
                        ErorMsg = errorMsg,
                        ObjectId = goodsId,
                        SourceType = (int)ChannelCatagroy.FxGoodsBuy
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool JobSuccess(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.JobSuccess;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.JobSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }


        public bool NoDelete(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.NoDelete;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.NoDelete)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }


        public bool Delete(int goodsId)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == goodsId).FirstOrDefault();
                if (goods != null)
                {
                    goods.InfoProcessState = (int)ProcessState.Delete;
                    goods.IsPublish = false;
                    goods.Logs.Add(new Entity.FxGoods.GoodsBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delete)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }
    }
}
