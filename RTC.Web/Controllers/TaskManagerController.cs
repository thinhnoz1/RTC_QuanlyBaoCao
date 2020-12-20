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

namespace RTC.Web.Controllers
{
    public class TaskManagerController : BaseController
    {
        private readonly IProjectService projectService;
        private readonly IEmployeeService employeeService;
        public TaskManagerController(
          IProjectService _projectService,
          IEmployeeService _employeeService)
        {
            this.projectService = _projectService;
            this.employeeService = _employeeService;
        }
        // GET: TaskManager
        public ActionResult Index()
        {
            return View();
        }
    }
}