using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Infrastructure
{
    public abstract class BaseIService<TContent> : IDisposable where TContent : IDisposable
    { 
        protected Lazy<TContent> content;
        private bool isDispose = false;

        public void Dispose()
        {
            if (!isDispose && content.Value != null)
            {
                content.Value.Dispose();
                isDispose = true;
            }
        }
    }
}
