using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Fx.Entity.FxCar;
using Fx.Entity.Catagroy;

namespace Fx.Domain.FxCar
{
    public class CarListService
    {
        public List<CarTransferInfo> GetSecondHandCar()
        {
            List<CarTransferInfo> list;
            using (FxCarContext context = new FxCarContext())
            {
                list = context.CarTransferInfos.Include(r => r.Pictures)
                    .Where(r => r.IsPublish && r.CarTransferInfoId == (int)ChannelListCatagroy.SecondHandCar)
                    .OrderByDescending(r => r.CreatedTime)
                    .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take<CarTransferInfo>((list.Count - (list.Count % 4))).ToList<CarTransferInfo>();
            }
            return list;
        }
    }
}
