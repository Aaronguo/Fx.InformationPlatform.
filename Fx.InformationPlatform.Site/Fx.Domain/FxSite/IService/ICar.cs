using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite.IService
{
    public interface ICar
    {
        List<ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName);

        List<ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName);

        /// <summary>
        /// 获取汽车允许显示的生产年份
        /// </summary>
        /// <returns></returns>
        List<int> GetCarShowYear();

        /// <summary>
        ///  获取汽车显示的英里数
        /// </summary>
        /// <returns></returns>
        Dictionary<int,string> GetCarMileage();
    }
}
