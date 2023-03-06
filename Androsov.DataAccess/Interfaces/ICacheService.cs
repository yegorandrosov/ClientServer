﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Androsov.DataAccess.Interfaces
{
    public interface ICacheService
    {
        bool TryGet<T>(string cacheKey, out T value);
        T Set<T>(string cacheKey, T value);
        void Remove(string cacheKey);
    }
}
