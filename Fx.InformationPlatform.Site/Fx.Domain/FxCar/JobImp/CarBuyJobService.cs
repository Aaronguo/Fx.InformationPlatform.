using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;
using Fx.Entity;

namespace Fx.Domain.FxCar
{
    public class CarBuyJobService : ICarBuyJob
    {
        public bool Authorizing(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Authorizing;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Authorizing)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool AuthorizeSuccess(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.AuthorizeSuccess;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeSuccess)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool AuthorizeFaild(int carId, string msg)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    car.ErrorMsg = msg;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)                        
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictureProcessdSuccessd(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Publish(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Publish;
                    car.IsPublish = true;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Publish)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Delay(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Delay;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Delay)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool End(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.End;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.End)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }




        public bool NoDelete(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.NoDelete;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.NoDelete)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }


        public bool Delete(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarBuyInfos.Where(r => r.CarBuyInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Delete;
                    car.IsDelete = true;
                    car.IsPublish = false;
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
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
