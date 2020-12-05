namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class RTC_DailyReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReportID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public virtual RTC_Employee RTC_Employee { get; set; }

        public virtual IEnumerable<RTC_ReportDetail> RTC_ReportDetail { get; set; }
    }
}
