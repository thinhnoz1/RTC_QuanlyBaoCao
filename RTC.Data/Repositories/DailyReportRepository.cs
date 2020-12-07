using PagedList;
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
    public class DailyReportRepository : RepositoryBase<RTC_DailyReport>, IDailyReportRepository
    {
        public DailyReportRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<RTC_DailyReport> ListAllPaging(int page, int pageSize)
        {
            return this.DbContext.RTC_DailyReports.OrderByDescending(x => x.DateCreated).ToPagedList(page, pageSize);
        }

        public IEnumerable<RTC_DailyReport> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<RTC_DailyReport> model = this.DbContext.RTC_DailyReports;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.FullName.Contains(searchString)).OrderByDescending(x => x.DateCreated);
            }
            return model.OrderByDescending(x => x.DateCreated).ToPagedList(page, pageSize);
        }
    }
}
