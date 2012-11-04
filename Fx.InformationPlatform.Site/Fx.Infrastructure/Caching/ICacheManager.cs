#region Copyright

//  Weapsy - http://www.weapsy.org
//  Copyright (c) 2011-2012 Luca Cammarata Briguglia
//  Licensed under the Weapsy Public License Version 1.0 (WPL-1.0)
//  A copy of this license may be found at http://www.weapsy.org/Documentation/License.txt

#endregion

using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace Fx.Infrastructure.Caching
{

	public interface ICacheManager
	{

        void Insert(string Key, object Obj, double TimeOut, CacheItemPriority Priority);

        void Insert(string Key, object Obj, CacheDependency Dependency, double TimeOut, TimeSpan SlidingExpiration, CacheItemPriority Priority, CacheItemRemovedCallback RemovedCallback);

        object Get(string Key);

        void Remove(string Key);

        void RemoveByPattern(string pattern);

        void Clear();

        Dictionary<byte, string> CacheItemPriorities();
	}

}