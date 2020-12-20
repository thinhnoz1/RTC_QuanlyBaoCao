using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace RTC.Model.Models
{
    public class RTC_TaskList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public int ProjectID { get; set; }

        [Required]
        [StringLength(1000)]
        public string ProjectName { get; set; }

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public int UserID { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public long ParentID { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

        public string UrlFiles { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
