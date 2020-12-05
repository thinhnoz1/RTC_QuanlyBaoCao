using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.Infrastructure
{
     public class DbFactory : Disposable, IDbFactory 
    {
        private RTCDbContext dbContext;
        public RTCDbContext Init()
        {
            return dbContext ?? (dbContext = new RTCDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
