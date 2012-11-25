using System;
using System.Linq;
using Fx.Domain.FxHouse.IService;
using Fx.Entity;

namespace Fx.Domain.FxHouse
{
    public class HouseTransferJobService : IHouseTransferJob
    {
        public bool Authorizing(int housId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Authorizing;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Authorizing)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool AuthorizeSuccess(int housId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.AuthorizeSuccess;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool AuthorizeFaild(int housId,string msg)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    house.ErrorMsg = msg;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictrueCdning(int housId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.PictrueCdning;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdning)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictrueCdnSuccessd(int housId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.PictrueCdnSuccessd;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnSuccessd)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictrueCdnFailed(int housId, string errorMsg)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.PictrueCdnFailed;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnFailed)
                    });
                    context.PictureCdnErrors.Add(new PictureCdnError()
                    {
                        ErorMsg = errorMsg,
                        ObjectId = housId,
                        SourceType = (int)SoureceCatagry.CarTransfer
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool JobSuccess(int housId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.JobSuccess;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.JobSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Publish(int housId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Publish;
                    house.IsPublish = true;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Publish)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Delay(int housId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Delay;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delay)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool End(int housId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseTransferInfos.Where(r => r.HouseTransferInfoId == housId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.End;
                    house.Logs.Add(new Entity.FxHouse.HouseTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.End)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }



       
    }
}
