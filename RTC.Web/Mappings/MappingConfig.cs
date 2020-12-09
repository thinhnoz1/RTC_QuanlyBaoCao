using AutoMapper;
using RTC.Common.ViewModels;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTC.Web.Mappings
{
    public class MappingConfig : Profile
    {
       public MappingConfig()
        {
            CreateMap<RTC_DailyReport, DailyReportViewModel>();
            CreateMap<RTC_Employee, EmployeeViewModel>();
            CreateMap<RTC_Project, ProjectViewModel>();
            CreateMap<RTC_ReportDetail, ReportDetailViewModel>();

        }
    }
}