using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Common.ViewModels
{
    public class DailyReportViewModel
    {
        public long ReportID { get; set; }

        public int UserID { get; set; }

        public DateTime DateCreated { get; set; }

        public string FullName { get; set; }

        public virtual EmployeeViewModel RTC_Employee { get; set; }

        public virtual IEnumerable<ReportDetailViewModel> RTC_ReportDetail { get; set; }

    }
}
