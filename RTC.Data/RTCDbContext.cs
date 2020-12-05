using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data
{
    public class RTCDbContext : DbContext
    {
        public RTCDbContext() : base("RTCConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }

        public  DbSet<RTC_Account> RTC_Accounts { get; set; }
        public  DbSet<RTC_DailyReport> RTC_DailyReports { get; set; }
        public  DbSet<RTC_Department> RTC_Departments { get; set; }
        public  DbSet<RTC_Employee> RTC_Employees { get; set; }
        public  DbSet<RTC_Project> RTC_Projects { get; set; }
        public  DbSet<RTC_ProjectMember> RTC_ProjectMembers { get; set; }
        public  DbSet<RTC_ReportDetail> RTC_ReportDetails { get; set; }
        public  DbSet<RTC_Role> RTC_Roles { get; set; }
        public  DbSet<RTC_Team> RTC_Team { get; set; }
        public  DbSet<RTC_TeamMember> RTC_TeamMember { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}
