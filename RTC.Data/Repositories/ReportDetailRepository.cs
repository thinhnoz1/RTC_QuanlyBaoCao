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
    public class ReportDetailRepository : RepositoryBase<RTC_ReportDetail>, IReportDetailRepository
    {
        public ReportDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        

        public RTC_ReportDetail GetByID(long id)
        {
            return this.DbContext.RTC_ReportDetails.SingleOrDefault(x => x.ProjectID == id);
        }

  
    }
}
