using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RTC.Common.ViewModels;
using RTC.Model.Models;
using RTC.Common.Common;

namespace RTC.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IReportDetailService reportDetailService;
        private readonly IProjectService projectService;
        private readonly IEmployeeService employeeService;

        public AdminController(
            IReportDetailService _reportDetailService,
            IProjectService _projectService,
            IEmployeeService _employeeService)
        {
            this.reportDetailService = _reportDetailService;
            this.projectService = _projectService;
            this.employeeService = _employeeService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}