namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class RTC_Role
    {
        [Key]
        public int RoleID { get; set; }

        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
