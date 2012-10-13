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
            result.isSuccess = isSuccess;
            result.ResultMsg = retultMsg;
            result.error = ex;
            result.Tag = Tag;
            return result;
        }
    }
}
