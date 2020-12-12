using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Common.ViewModels
{
    public class ReportDetailViewModel
    {
        public long ReportID { get; set; }
        public int ProjectID { get; set; }
        public string WorkDetail { get; set; }
        public string WorkFinished { get; set; }
        public string ProblemRemained { get; set; }
        public string ExpectedSolution { get; set; }
        public string NextDayWork { get; set; }
        public string Note { get; set; }
        public string ProjectCode { get; set; }
        public DateTime DateCreated { get; set; }


        public virtual ProjectViewModel RTC_Project { get; set; }
    }
}
