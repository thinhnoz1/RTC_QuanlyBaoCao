using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RTC.Service.IServices
{
    public interface IDailyReportService
    {
        void Add(RTC_DailyReport report);
        void Update(RTC_DailyReport report);
        void Delete(RTC_DailyReport report);
        void Delete(int id);
        IEnumerable<RTC_DailyReport> GetAll();
        IEnumerable<RTC_DailyReport> GetAll(string keyword);
        RTC_DailyReport GetByReportID(int id);
        IEnumerable<RTC_DailyReport> ListAllPaging(string searchString, int page, int pageSize);
        IEnumerable<RTC_DailyReport> ListAllPaging(int page, int pageSize);

        void SaveChanges();
    }
}
