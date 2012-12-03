using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base.IService
{
    public interface ICarSearch<T> where T : class
    {
        List<T> SearchByCatagroy(Fx.Entity.Catagroy.ChannelListDetailCatagroy catagroy, int page, int take);
    }
}
