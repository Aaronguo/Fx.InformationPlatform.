using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;
using Fx.Entity;

namespace Fx.Domain.FxCar
{
    public class CarJobService : ICarBuyJob
    {
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


        public bool AuthorizeFaild(int carId)
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
                    car.Logs.Add(new Entity.FxCar.CarBuyLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.Publish)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }
    }
}
