using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.Repositories
{
    public class BackgroundImageRepository : RepositoryBase<RTC_BackgroundImage>, IBackgroundImageRepository
    {
        public BackgroundImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
