namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class RTC_Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        [StringLength(100)]
        public string ProjectCode { get; set; }

        [StringLength(1000)]
        public string ProjectName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStarted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateEnded { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDateExpected { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDateExpected { get; set; }

        public virtual IEnumerable<RTC_ProjectMember> RTC_ProjectMember { get; set; }

        public virtual IEnumerable<RTC_ReportDetail> RTC_ReportDetail { get; set; }
    }
}
