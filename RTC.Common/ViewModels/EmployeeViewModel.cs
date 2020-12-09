using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Common.ViewModels
{
    public class EmployeeViewModel
    {
        public int UserID { get; set; }

        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? JoinedDate { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }
        public virtual IEnumerable<DailyReportViewModel> RTC_DailyReport { get; set; }


    }
}
