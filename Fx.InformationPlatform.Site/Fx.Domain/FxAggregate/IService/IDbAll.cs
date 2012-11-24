using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 所有的数据库聚合接口
    /// </summary>
    public interface IDbAll
    {
        /// <summary>
        /// 所有帖子的数量
        /// </summary>
        /// <returns></returns>
        long InfoCount();


        long InfoEndCount();
    }
}
