using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Domain
{
    public class DomainResult
    {
        public DomainResult(bool isSuccess)
        {
            this.isSuccess = isSuccess;
        }

        public bool isSuccess { get; set; }

        public string ResultMsg { get; set; }

        public Exception error { get; set; }

        public object Tag { get; set; }

        private static DomainResult result = new DomainResult(true);

        /// <summary>
        ///  默认成功
        /// </summary>
        /// <returns></returns>
        public static DomainResult GetDefault()
        {
            return result;
        }

        public DomainResult SetResult(string retultMsg="", Exception ex = null, string Tag = "",bool isSuccess = false)
        {
            //解决公用一个DomainResult而导致的冲突问题
            var copyone = result.MemberwiseClone() as DomainResult;
            copyone.isSuccess = isSuccess;
            copyone.ResultMsg = retultMsg;
            copyone.error = ex;
            copyone.Tag = Tag;
            return copyone;
        }
    }
}
