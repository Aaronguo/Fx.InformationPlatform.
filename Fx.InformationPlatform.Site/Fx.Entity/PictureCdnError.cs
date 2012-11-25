using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
   public class PictureCdnError
    {
       public int PictureCdnErrorId { get; set; }

       public string ErorMsg { get; set; }

       /// <summary>
       /// 关联对象Id
       /// </summary>
       public int ObjectId { get; set; }

       /// <summary>
       /// 来源对象类型 ChannelCatagroy
       /// </summary>
      
       public int SourceType { get; set; }
    }
}
