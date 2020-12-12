namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Xml.Linq;

    public class RTC_Employee
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? JoinedDate { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public string Image { get; set; }


        public virtual IEnumerable<RTC_Account> RTC_Account { get; set; }
        public virtual IEnumerable<RTC_Department> RTC_Department { get; set; }
        public virtual IEnumerable<RTC_ProjectMember> RTC_ProjectMember { get; set; }
        public virtual IEnumerable<RTC_TeamMember> RTC_TeamMember { get; set; }


    }
}
