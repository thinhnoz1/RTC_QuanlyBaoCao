using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RTC.Common.ViewModels;
using RTC.Model.Models;
using RTC.Common.Common;
using RTC.Web.Controllers;

namespace RTC.Web.Areas.Admin.Controllers
{
    public class ReportAdminController : AdminBaseController
    {
        private readonly IReportDetailService reportDetailService;
        private readonly IProjectService projectService;
        private readonly IEmployeeService employeeService;

        public ReportAdminController(
           IReportDetailService _reportDetailService,
           IProjectService _projectService,
           IEmployeeService _employeeService)
        {
            this.reportDetailService = _reportDetailService;
            this.projectService = _projectService;
            this.employeeService = _employeeService;
        }

        // GET: Admin/ReportAdmin
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
        public ActionResult SubmitForm(RTC_ReportDetail reportDetail)
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
                var test = reportDetailService.GetReportByDate();
                if (test != null)
                {
                    test = test.ToList();

                    //Initialize
                    List<ReportModel> list = new List<ReportModel>();
                    ReportModel token = new ReportModel();
                    RTC_Project listProject = new RTC_Project();
                    RTC_Employee employee = new RTC_Employee();

                    if (test.Count() > 0)
                    {
                        foreach (var item in test)
                        {
                            listProject = projectService.GetByProjectID(item.ProjectID);
                            employee = employeeService.GetByID(item.UserID);

                            token.ReportID = item.ReportID;
                            token.ProjectID = item.ProjectID;
                            token.ProjectCode = listProject.ProjectCode;
                            token.ProjectName = listProject.ProjectName;
                            token.UserID = item.UserID;
                            token.FullName = employee.FullName;
                            token.WorkDetail = item.WorkDetail;
                            token.WorkFinished = item.WorkFinished;
                            token.ProblemRemained = item.ProblemRemained;
                            token.ExpectedSolution = item.ExpectedSolution;
                            token.NextDayWork = item.NextDayWork;
                            token.Note = item.Note;
                            token.DateCreated = item.DateCreated;

                            list.Add(token);
                        }
                        return AjaxResult(true, "success", list);
                    }
                    else
                        return AjaxResult(false, "error", null);
                }
                else return AjaxResult(false, "error", null);

            }
            catch (Exception e)
            {
                return AjaxResult(false, "error", null, e.Message);
            }

        }

    }
}