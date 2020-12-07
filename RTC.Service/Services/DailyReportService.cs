using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.Services
{
    public class DailyReportService : IDailyReportService
    {
        IDailyReportRepository dailyReportRepository;
        IUnitOfWork unitOfWork;

        public DailyReportService(IDailyReportRepository _dailyReportRepository, IUnitOfWork _unitOfWork)
        {
            this.dailyReportRepository = _dailyReportRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(RTC_DailyReport report)
        {
            dailyReportRepository.Add(report);
        }

        public void Delete(RTC_DailyReport report)
        {
            dailyReportRepository.Delete(report);
        }

        public void Delete(int id)
        {
            dailyReportRepository.Delete(id);
        }

        public IEnumerable<RTC_DailyReport> GetAll()
        {
            return dailyReportRepository.GetAll();
        }

        public IEnumerable<RTC_DailyReport> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                int id = int.Parse(keyword);
                return dailyReportRepository.GetMulti(x => x.FullName.Contains(keyword) || x.ReportID.Equals(id));
            }
            else
                return dailyReportRepository.GetAll();
        }

        public RTC_DailyReport GetByReportID(int id)
        {
            return dailyReportRepository.GetSingleById(id);
        }

        public IEnumerable<RTC_DailyReport> ListAllPaging(string searchString, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return dailyReportRepository.ListAllPaging(searchString, page, pageSize);
            }
            else
            {
                return dailyReportRepository.GetAll();
            }
        }

        public IEnumerable<RTC_DailyReport> ListAllPaging(int page, int pageSize)
        {
            return dailyReportRepository.ListAllPaging(page, pageSize);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(RTC_DailyReport report)
        {
            throw new NotImplementedException();
        }
    }
}
