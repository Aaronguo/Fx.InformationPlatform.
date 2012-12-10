using System;
using System.Linq;
using Fx.Domain.FxHouse.IService;
using Fx.Entity;

namespace Fx.Domain.FxHouse
{
    public class HouseBuyJobService : IHouseBuyJob
    {
        public bool Authorizing(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Authorizing;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Authorizing)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool AuthorizeSuccess(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.AuthorizeSuccess;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool AuthorizeFaild(int houseId,string msg)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    house.ErrorMsg = msg;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictureProcessdSuccessd(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Publish(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Publish;
                    house.IsPublish = true;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Publish)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Delay(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Delay;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delay)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool End(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.End;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.End)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }




        public bool NoDelete(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.NoDelete;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.NoDelete)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }


        public bool Delete(int houseId)
        {
            using (var context = new FxHouseContext())
            {
                var house = context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == houseId).FirstOrDefault();
                if (house != null)
                {
                    house.InfoProcessState = (int)ProcessState.Delete;
                    house.IsPublish = false;
                    house.Logs.Add(new Entity.FxHouse.HouseBuyLog()
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
