using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Fx.Infrastructure
//{

    //[Obsolete("移除此类的使用 在Content层面上去做Lazy有点傻")]
    //public abstract class BaseIService<TContent> : IDisposable where TContent : IDisposable
    //{
    //    protected Lazy<TContent> content;
    //    private bool isDispose = false;

    //    public void Dispose()
    //    {
    //        if (!isDispose && content.Value != null)
    //        {
    //            content.Value.Dispose();
    //            isDispose = true;
    //        }
    //    }
    //}
//}