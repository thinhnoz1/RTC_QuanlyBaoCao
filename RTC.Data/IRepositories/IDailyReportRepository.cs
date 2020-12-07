using RTC.Data.Infrastructure;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RTC.Data.IRepositories
{
    public interface IDailyReportRepository : IRepository<RTC_DailyReport>
    {
        IEnumerable<RTC_DailyReport> ListAllPaging(int page, int pageSize);
        IEnumerable<RTC_DailyReport> ListAllPaging(string searchString, int page, int pageSize);
    }
    
}
