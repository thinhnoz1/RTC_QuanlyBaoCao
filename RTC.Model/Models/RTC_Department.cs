namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class RTC_Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }

        [StringLength(1000)]
        public string DepartmentName { get; set; }

        public int? DepartmentChief { get; set; }

        public virtual RTC_Employee RTC_Employee { get; set; }

        public virtual IEnumerable<RTC_Team> RTC_Team { get; set; }
    }
}
