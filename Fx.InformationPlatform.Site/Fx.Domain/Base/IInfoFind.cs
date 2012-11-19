using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base
{
    /// <summary>
    /// 帖子查询接口
    /// </summary>
    public interface IInfoFind<T> where T : class
    {
        //查询审核中的信息
        List<T> FindCommitInfo(string user);

        //查询已发布的信息
        List<T> FindPublishInfo(string user);

        //查询已成交的信息
        List<T> FindEndInfo(string user);

        //查询置顶的信息
        List<T> FindTopInfo(string user);
    }
}
