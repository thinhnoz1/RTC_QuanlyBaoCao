using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.Services
{
    public class ReportDetailService : IReportDetailService
    {
        IReportDetailRepository reportDetailRepository;
        IUnitOfWork unitOfWork;

        public ReportDetailService(IReportDetailRepository _reportDetailRepository, IUnitOfWork _unitOfWork)
        {
            this.reportDetailRepository = _reportDetailRepository;
            this.unitOfWork = _unitOfWork;
        }
        public void Add(RTC_ReportDetail report)
        {
            reportDetailRepository.Add(report);
        }

        public void Delete(long id)
        {
            reportDetailRepository.Delete(id);
        }

        public RTC_ReportDetail GetByID(long id)
        {
            return reportDetailRepository.GetByID(id);
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void Update(RTC_ReportDetail report)
        {
            reportDetailRepository.Update(report);
        }
        public RTC_ReportDetail GetInfoByObj(RTC_ReportDetail reportDetail)
        {
            return reportDetailRepository.GetInfoByObj(reportDetail);
        }

        /*public IEnumerable<RTC_ReportDetail> GetWithCondition(int userID, int projectID)
        {
            return reportDetailRepository.GetMulti(x => x.);
        }*/
    }
}
