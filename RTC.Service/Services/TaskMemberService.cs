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
    public class TaskMemberService : ITaskMemberService
    {
        ITaskMemberRepository taskMemberRepository;
        IUnitOfWork unitOfWork;

        public TaskMemberService(ITaskMemberRepository _taskMemberRepository, IUnitOfWork _unitOfWork)
        {
            this.taskMemberRepository = _taskMemberRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(RTC_TaskMember task)
        {
            taskMemberRepository.Add(task);
        }

        public void Delete(long id)
        {
            taskMemberRepository.Delete(id);
        }

        public void DeleteMulti(long id)
        {
            taskMemberRepository.DeleteMulti(x => x.TaskID == id);
        }



        public IEnumerable<RTC_TaskMember> GetAll(long taskID)
        {
            return taskMemberRepository.GetMulti(x => x.TaskID == taskID);
        }
        public IEnumerable<RTC_TaskMember> GetAll(int projectID)
        {
            return taskMemberRepository.GetMulti(x => x.ProjectID == projectID);
        } 
        
        public List<int> GetUserProject(int userid)
        {
            var firstList = taskMemberRepository.GetMulti(x => x.UserID == userid).ToList();
            var secondList = firstList.Select(x => x.ProjectID);
            var result = secondList.Distinct().ToList();
            return result;
        }

        public IEnumerable<RTC_TaskMember> GetAll()
        {
            return taskMemberRepository.GetAll();
        }

        public RTC_TaskMember GetByID(long id)
        {
            return taskMemberRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void Update(RTC_TaskMember task)
        {
            taskMemberRepository.Update(task);
        }

        public void DeleteMultiByProjectID(int id)
        {
            taskMemberRepository.DeleteMulti(x => x.ProjectID == id);
        }
    }
}
