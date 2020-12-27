using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.IServices
{
    public interface ITaskMemberService
    {
        void Add(RTC_TaskMember task);
        void Update(RTC_TaskMember task);
        void Delete(long id);
        void DeleteMulti(long id);
        RTC_TaskMember GetByID(long id);
        void SaveChanges();
        IEnumerable<RTC_TaskMember> GetAll(long taskID);
        IEnumerable<RTC_TaskMember> GetAll();
        IEnumerable<RTC_TaskMember> GetAll(int projectID);
    }
}
