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
    public class ProjectManagerController : BaseController
    {
        private readonly IProjectService projectService;
        private readonly IBackgroundImageService backgroundImageService;
        private readonly ITaskMemberService taskMemberService;
        private readonly IProjectMemberService projectMemberService;
        private readonly ITaskListService taskListService;

        public ProjectManagerController(
          IProjectService _projectService,
          IBackgroundImageService _backgroundImageService,
          ITaskMemberService _taskMemberService,
          IProjectMemberService _projectMemberService,
          ITaskListService _taskListService)
        {
            this.projectService = _projectService;
            this.backgroundImageService = _backgroundImageService;
            this.taskMemberService = _taskMemberService;
            this.projectMemberService = _projectMemberService;
            this.taskListService = _taskListService;
        }

        // GET: ProjectManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProjectList()
        {
            var list = projectService.GetAll();
            return AjaxResult(true, "success", list);
        }

        public ActionResult GetBGImageList()
        {
            var list = backgroundImageService.GetAll();
            return AjaxResult(true, "success", list);
        }

        public ActionResult GetListUserOwnedProject ()
        {
            try
            {
                var session = (AccountLogin)Session[CommonConstants.USER_SESSION];
                var list = projectMemberService.GetUserProject(session.UserID);
                List<RTC_Project> result = new List<RTC_Project>();
                foreach (var i in list)
                {
                    var temp = projectService.GetByProjectID(i);
                    result.Add(temp);
                }
                return AjaxResult(true, "success", result);
            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }

        public ActionResult GetListUserJoinedProject()
        {
            var session = (AccountLogin)Session[CommonConstants.USER_SESSION];
            var list = taskMemberService.GetUserProject(session.UserID);
          
            

            List<RTC_Project> result = new List<RTC_Project>();

            foreach (var i in list)
            {
                var temp = projectService.GetByProjectID(i);
                result.Add(temp);
            }
            
            return AjaxResult(true, "success", result);
        }

        public ActionResult AddProject(RTC_Project project)
        {
            try
            {
                var session = (AccountLogin)Session[CommonConstants.USER_SESSION];

                project.DateStarted = DateTime.Now;
                projectService.Add(project);
                projectService.SaveChanges();

                var member = new RTC_ProjectMember();
                member.ProjectID = project.ProjectID;
                member.UserID = session.UserID;
                member.FullName = session.FullName;

                projectMemberService.Add(member);
                projectMemberService.SaveChanges();
                return AjaxResult(true);
            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }

        public ActionResult DeleteProject(int id)
        {
            projectService.Delete(id);
            projectService.SaveChanges();
            taskListService.DeleteMultiByParentID(id);
            taskListService.SaveChanges();
            taskMemberService.DeleteMultiByProjectID(id);
            taskMemberService.SaveChanges();
            projectMemberService.DeleteMultiByProjectID(id);
            projectMemberService.SaveChanges();
            return AjaxResult(true);
        }
    }
}