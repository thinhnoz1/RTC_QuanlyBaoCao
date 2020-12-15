using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTC.Model.Models
{
    public class ReportModel
    {
        public long ReportID { get; set; }

        public int ProjectID { get; set; }

        [StringLength(100)]
        public string ProjectCode { get; set; }
        [StringLength(1000)]
        public string ProjectName { get; set; }

        public int UserID { get; set; }
        public string FullName { get; set; }
        public string WorkDetail { get; set; }

        public string WorkFinished { get; set; }

        public string ProblemRemained { get; set; }

        public string ExpectedSolution { get; set; }

        public string NextDayWork { get; set; }

        public string Note { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }
    }
}
