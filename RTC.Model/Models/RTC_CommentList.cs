using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace RTC.Model.Models
{
    public class RTC_CommentList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long TaskID { get; set; }

        public int UserID { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public string CommentDetail { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
