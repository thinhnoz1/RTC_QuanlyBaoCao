using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Common.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectID { get; set; }

        public string ProjectCode { get; set; }

        public string ProjectName { get; set; }

        public DateTime? DateStarted { get; set; }

        public DateTime? DateEnded { get; set; }

        public DateTime? StartDateExpected { get; set; }

        public DateTime? EndDateExpected { get; set; }

        public virtual IEnumerable<ReportDetailViewModel> RTC_ReportDetail { get; set; }

    }
}
