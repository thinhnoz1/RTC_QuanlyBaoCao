namespace RTC.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class RTC_Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int AccountType { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual RTC_Employee RTC_Employee { set; get; }
    }
}
