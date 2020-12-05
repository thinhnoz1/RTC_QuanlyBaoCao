namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RTC_Team")]
    public class RTC_Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TeamID { get; set; }

        [StringLength(50)]
        public string TeamName { get; set; }

        [StringLength(100)]
        public string LeaderName { get; set; }

        public int? DepartmentID { get; set; }

        public virtual RTC_Department RTC_Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IEnumerable<RTC_TeamMember> RTC_TeamMember { get; set; }
    }
}
