using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.Base
{
    public class CommonSearch
    {
        protected StringBuilder CreateCommonSearch(string key, int area, int city)
        {
            var sb = new StringBuilder();
            sb.Append(" where IsPublish='True' ");
            if (!string.IsNullOrWhiteSpace(key))
            {
                sb.Append(string.Format(" and PublishTitle like N'%{0}%' ", key));
            }
            if (area > 0)
            {
                sb.Append(string.Format(" and AreaId={0}", area));

            }
            if (city > 0)
            {
                sb.Append(string.Format(" and CityId={0}", city));

            }
            return sb;
        }
        
    }
}
