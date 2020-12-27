using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Model.Models
{
    public class RTC_TaskMember
    {
        [Key]
        public long id { get; set; }
        public long TaskID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
    }
}
