using RTC.Service.IServices;
using System.Web.Mvc;

namespace RTC.Web.Controllers
{
    public class ProjectManagerController : BaseController
    {
        private readonly IProjectService projectService;
        private readonly IEmployeeService employeeService;
        private readonly ITaskListService taskListService;
        private readonly ICommentListService commentListService;
        private readonly ITaskMemberService taskMemberService;
        public ProjectManagerController (
          IProjectService _projectService,
          IEmployeeService _employeeService,
          ITaskListService _taskListService,
          ICommentListService _commentListService,
          ITaskMemberService _taskMemberService)
        {
            this.projectService = _projectService;
            this.employeeService = _employeeService;
            this.taskListService = _taskListService;
            this.commentListService = _commentListService;
            this.taskMemberService = _taskMemberService;
        }

        // GET: ProjectManager
        public ActionResult Index()
        {
            return View();
        }

    }
}