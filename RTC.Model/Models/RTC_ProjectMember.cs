namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class RTC_ProjectMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int ProjectID { get; set; }

        public int UserID { get; set; }

        public int? RoleID { get; set; }

        public string FullName { get; set; }

        public virtual RTC_Employee RTC_Employee { get; set; }

        public virtual RTC_Project RTC_Project { get; set; }
    }
}
