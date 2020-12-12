using RTC.Data.Infrastructure;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.IRepositories
{
    public interface IReportDetailRepository : IRepository<RTC_ReportDetail>
    {
        RTC_ReportDetail GetByID(long id);
        RTC_ReportDetail GetInfoByObj(RTC_ReportDetail reportDetail);
    }
}
