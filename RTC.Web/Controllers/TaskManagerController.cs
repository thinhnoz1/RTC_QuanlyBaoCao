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
        private readonly ITaskListService taskListService;
        private readonly ICommentListService commentListService;
        private readonly ITaskMemberService taskMemberService;
        private readonly IProjectMemberService projectMemberService;
        public TaskManagerController(
          IProjectService _projectService,
          IEmployeeService _employeeService,
          ITaskListService _taskListService,
          ICommentListService _commentListService,
          ITaskMemberService _taskMemberService,
          IProjectMemberService _projectMemberService)
        {
            this.projectService = _projectService;
            this.employeeService = _employeeService;
            this.taskListService = _taskListService;
            this.commentListService = _commentListService;
            this.taskMemberService = _taskMemberService;
            this.projectMemberService = _projectMemberService;
        }

        // GET: TaskManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjectDetail (int projectID)
        {
            var session = (AccountLogin)Session[CommonConstants.USER_SESSION];
            var list = taskMemberService.GetUserProject(session.UserID);
            var list2 = projectMemberService.GetUserProject(session.UserID);
            if (list.Contains(projectID) == true || list2.Contains(projectID) == true)
            {
                var data = projectService.GetByProjectID(projectID);
                ViewBag.ProjectName = data.ProjectCode + " " + data.ProjectName;
                return View(data.ProjectID);
            }
            else
            {
                return RedirectToAction("Index", "ProjectManager");
            }
        }

        public ActionResult GetTaskList(int projectID)
        {
            try
            {
                var taskList = taskListService.GetAll(projectID);
                return AjaxResult(true, "success", taskList);
            }
            catch (Exception e)
            {
                return AjaxResult(false, "error", null, e.Message);
            }
        }

        public ActionResult DeleteTask (long id)
        {
            try
            {
                if (id != 0)
                {
                    taskListService.Delete(id);
                    taskMemberService.DeleteMulti(id);
                    taskMemberService.SaveChanges();
                    taskListService.SaveChanges();
                    return AjaxResult(true, "success");
                }
                else return AjaxResult(false, "error");
            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }

        public ActionResult DeleteColumn(long id, List<RTC_TaskList> listChild)
        {
            try
            {
                if (id != 0)
                {
                    taskListService.Delete(id);
                    taskListService.DeleteMulti(id);
                    if(listChild != null)
                    {
                        foreach (var i in listChild)
                        {
                            taskMemberService.DeleteMulti(i.id);
                        }

                        taskMemberService.SaveChanges();
                    }
                    taskListService.SaveChanges();
                    return AjaxResult(true, "success");
                }
                else return AjaxResult(false, "error");
            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }

        public ActionResult SubmitTask(RTC_TaskList task)
        {
            try
            {
                if (task.id == 0)
                {
                    task.DateCreated = DateTime.Now;
                    taskListService.Add(task);
                    taskListService.SaveChanges();
                    return AjaxResult(true);
                }
               else
                {
                   
                        task.DateModified = DateTime.Now;
                        taskListService.Update(task);
                        taskListService.SaveChanges();
                        return AjaxResult(true);
                   
                }

            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }
        
        public ActionResult EditColumn(RTC_TaskList task, int? current)
        {
            try
            {
                if (task.ColumnOrder < current)
                {
                    var listCol = taskListService.GetOthersColumn(task.ProjectID, task.ColumnOrder, current).ToList();
                    foreach (var item in listCol)
                    {
                        if (item.id != task.id)
                        {
                            item.DateModified = DateTime.Now;
                            item.ColumnOrder = item.ColumnOrder + 1;
                            taskListService.Update(item);
                        }
                        else break;
                    }
                    task.DateModified = DateTime.Now;
                    taskListService.Update(task);
                    taskListService.SaveChanges();
                    return AjaxResult(true);
                }
                else
                {
                    var listCol = taskListService.GetOthersColumn(task.ProjectID, task.ColumnOrder, current).ToList();
                    foreach (var item in listCol)
                    {
                        if (item.id != task.id)
                        {
                            item.DateModified = DateTime.Now;
                            item.ColumnOrder = item.ColumnOrder - 1;
                            taskListService.Update(item);
                            taskListService.SaveChanges();
                        }
                        else break;
                    }
                    task.DateModified = DateTime.Now;
                    taskListService.Update(task);
                    taskListService.SaveChanges();
                    return AjaxResult(true);
                }

            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }

        public ActionResult GetListEmployee()
        {
            return AjaxResult(true, "success", employeeService.GetAll().ToList());
        }

        public ActionResult GetListTaskMember(long taskID)
        {
            try
            {
                if (taskID != null)
                {
                    return AjaxResult(true, "success", taskMemberService.GetAll(taskID).ToList());
                }
                else
                {
                    return AjaxResult(false, "Không lấy được TaskID", null);
                }
            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }

        public ActionResult GetAllListMember(int projectID)
        {
            try
            {
                    return AjaxResult(true, "success", taskMemberService.GetAll(projectID).ToList());
            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
        }

        public ActionResult AddWorker (List<RTC_TaskMember> listmember)
        {
            try
            {
                if (listmember.Count > 0)
                {
                    foreach (var item in listmember)
                    {
                        /*taskMemberService.DeleteMulti(listmember[0].TaskID);
                        taskMemberService.SaveChanges();*/
                        taskMemberService.Add(item);
                        taskMemberService.SaveChanges();
                    }
                    return AjaxResult(true);
                }
                else 
                {
                    return AjaxResult(false, "Không có dữ liệu đầu vào !");
                }
            }
            catch (Exception e)
            {
                return AjaxResult(false, "Lỗi hệ thống", null, e.Message);
            }
            
        }

        public ActionResult RemoveWorker (long id)
        {
            try
            {
                taskMemberService.Delete(id);
                taskMemberService.SaveChanges();
                return AjaxResult(true);
            }
            catch (Exception e)
            {
                return AjaxResult(false, "Xóa thất bại", null, e.Message);
            }
          
        }
    }
}