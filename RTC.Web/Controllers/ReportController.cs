using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RTC.Common.ViewModels;
using AutoMapper;
using RTC.Model.Models;
using RTC.Common.Common;

namespace RTC.Web.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IReportDetailService reportDetailService;
        private readonly IProjectService projectService;
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public ReportController(
            IReportDetailService _reportDetailService,
            IProjectService _projectService,
            IEmployeeService _employeeService)
        {
            this.reportDetailService = _reportDetailService;
            this.projectService = _projectService;
            this.employeeService = _employeeService;
        }
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProjectList()
        {
            try
            {
                var test1 = projectService.GetAll().ToList();
                return AjaxResult(true, "success", test1);
            }
            catch (Exception e)
            {
                return AjaxResult(false, "error", null, e.Message);
            }

        }

        public ActionResult GetUserInfo()
        {
            try
            {
                var session = (AccountLogin)Session[CommonConstants.USER_SESSION];
                var user = employeeService.GetByID(session.UserID);
                return AjaxResult(true, "success", user);
            }
            catch (Exception e)
            {
                return AjaxResult(false, "error", null, e.Message);
            }
        }

        [HttpPost]
        public ActionResult SubmitForm (RTC_ReportDetail reportDetail)
        {
            try
            {
                var session = (AccountLogin)Session[CommonConstants.USER_SESSION];

                reportDetail.DateCreated = DateTime.Now;
                reportDetail.UserID = session.UserID;
                reportDetailService.Add(reportDetail);
                reportDetailService.SaveChanges();

                return AjaxResult(true);

            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }

        public ActionResult Check()
        {
            try
            {
                var session = (AccountLogin)Session[CommonConstants.USER_SESSION];
                var test = reportDetailService.GetReportByDate(session.UserID).ToList();
                if (test.Count() > 0)
                {
                    return AjaxResult(true, "success", test);
                }
                else return AjaxResult(false, "error", null);
                
            }
            catch (Exception e)
            {
                return AjaxResult(false, "error", null, e.Message);
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }



    }
}