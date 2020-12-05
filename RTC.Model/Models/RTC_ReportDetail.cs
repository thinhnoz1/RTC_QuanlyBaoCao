namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class RTC_ReportDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ReportID { get; set; }

        public int ProjectID { get; set; }

        public string WorkDetail { get; set; }

        public string WorkFinished { get; set; }

        public string ProblemRemained { get; set; }

        public string ExpectedSolution { get; set; }

        [StringLength(100)]
        public string ProjectCode { get; set; }

        public string NextDayWork { get; set; }

        public string Note { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }

        public virtual RTC_DailyReport RTC_DailyReport { get; set; }

        public virtual RTC_Project RTC_Project { get; set; }
    }
}
