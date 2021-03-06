﻿using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.IServices
{
    public interface IReportDetailService
    {
        void Add(RTC_ReportDetail report);
        void Update(RTC_ReportDetail report);
        void Delete(long id);
        RTC_ReportDetail GetByID(long id);
        void SaveChanges();
        RTC_ReportDetail GetInfoByObj(RTC_ReportDetail reportDetail);
        IEnumerable<RTC_ReportDetail> GetReportByDate(int userID);
        IEnumerable<RTC_ReportDetail> GetAll(int id);
        IEnumerable<RTC_ReportDetail> GetAll();
        IEnumerable<RTC_ReportDetail> GetReportByDate();
        List<int> GetListUserReportedByDate();
    }
}
