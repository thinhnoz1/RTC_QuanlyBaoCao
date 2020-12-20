using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.Services
{
    public class TaskListService : ITaskListService
    {
        ITaskListRepository taskListRepository;
        IUnitOfWork unitOfWork;

        public void Add(RTC_TaskList task)
        {
             taskListRepository.Add(task);
        }

        public void Delete(long id)
        {
            taskListRepository.Delete(id);
        }

        public IEnumerable<RTC_TaskList> GetAll(int projectID)
        {
            return taskListRepository.GetMulti(x => x.ProjectID.Equals(projectID));
        }

        public IEnumerable<RTC_TaskList> GetAll()
        {
            return taskListRepository.GetAll();

        }

        public RTC_TaskList GetByID(long id)
        {
            return taskListRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void Update(RTC_TaskList task)
        {
            taskListRepository.Update(task);
        }
    }
}
