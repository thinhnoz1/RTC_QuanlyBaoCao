namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RTC_TeamMember")]
    public class RTC_TeamMember
    {

        [Key]
        [Column(Order = 0)]
        public int TeamID { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        public int? LeaderID { get; set; }

        public virtual RTC_Employee RTC_Employee { get; set; }

        public virtual RTC_Team RTC_Team { get; set; }
    }
}
