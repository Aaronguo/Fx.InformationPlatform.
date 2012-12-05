using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Entity.Catagroy;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar
{
    /// <summary>
    /// 用于CarList栏目中信息获取
    /// </summary>
    public class CarListService
    {
        public List<CarTransferInfo> GetSecondHandCar()
        {
            List<CarTransferInfo> list;
            using (FxCarContext context = new FxCarContext())
            {
                list = context.CarTransferInfos.Include(r => r.Pictures)
                    .Where(r => r.IsPublish)
                    .OrderByDescending(r => r.CreatedTime)
                    .Take(20).ToList();
                //&&
                //        (r.CarTransferInfoId >= (int)ChannelListDetailCatagroy.Audi &&
                //        r.CarTransferInfoId >= (int)ChannelListDetailCatagroy.SecondHandCarOther)
                //只有一个栏目 优化语句
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take(list.Count - (list.Count % 4)).ToList();
            }
            return list;
        }
    }
}
