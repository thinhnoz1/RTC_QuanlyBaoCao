using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RTC.Common.ViewModels;
using AutoMapper;

namespace RTC.Web.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IDailyReportService dailyReportService;
        private readonly IReportDetailService reportDetailService;
        private readonly IProjectService projectService;
        private readonly IMapper mapper;

        public ReportController(
            IDailyReportService _dailyReportService, 
            IReportDetailService _reportDetailService, 
            IProjectService _projectService,
            IMapper _mapper)
        {
            this.dailyReportService = _dailyReportService;
            this.reportDetailService = _reportDetailService;
            this.projectService = _projectService;
            this.mapper = _mapper;
        }
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }


    }
}