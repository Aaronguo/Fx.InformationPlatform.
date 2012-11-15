using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;
using Fx.Entity;

namespace Fx.Domain.FxCar
{
    public class CarTransferJobService : ICarTransferJob
    {
        public bool AuthorizeSuccess(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.AuthorizeSuccess;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
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
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.AuthorizeFaild;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.AuthorizeFaild)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }      

        public bool PictrueCdnSuccessd(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.PictrueCdnSuccessd;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnSuccessd)
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool PictrueCdnFailed(int carId, string errorMsg)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.PictrueCdnFailed;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.PictrueCdnFailed)
                    });
                    context.PictureCdnErrors.Add(new PictureCdnError()
                    {
                        ErorMsg = errorMsg,
                        ObjectId = carId,
                        SourceType = (int)SoureceCatagry.CarTransfer
                    });
                    return context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool JobSuccess(int carId)
        {
            using (var context = new FxCarContext())
            {
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.JobSuccess;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
                    {
                        OperteName = Enum.GetName(typeof(ProcessState), ProcessState.JobSuccess)
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
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Publish;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
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
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.Delay;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
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
                var car = context.CarTransferInfos.Where(r => r.CarTransferInfoId == carId).FirstOrDefault();
                if (car != null)
                {
                    car.InfoProcessState = (int)ProcessState.End;
                    car.Logs.Add(new Entity.FxCar.CarTransferLog()
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
