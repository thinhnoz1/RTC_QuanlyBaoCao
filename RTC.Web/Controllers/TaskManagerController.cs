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
        public TaskManagerController(
          IProjectService _projectService,
          IEmployeeService _employeeService,
          ITaskListService _taskListService,
          ICommentListService _commentListService)
        {
            this.projectService = _projectService;
            this.employeeService = _employeeService;
            this.taskListService = _taskListService;
            this.commentListService = _commentListService;
        }

        // GET: TaskManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjectDetail ()
        {
            var data = projectService.GetByProjectID(1);
            ViewBag.ProjectName = data.ProjectCode + " " + data.ProjectName;
            return View(data.ProjectID);
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

        public ActionResult DeleteColumn(long id)
        {
            try
            {
                if (id != 0)
                {
                    taskListService.Delete(id);
                    taskListService.DeleteMulti(id);
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
    }
}