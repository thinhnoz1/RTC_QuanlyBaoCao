﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        RTCDbContext Init();
    }
}
