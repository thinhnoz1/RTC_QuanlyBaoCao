using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.IServices
{
    public interface ITaskListService
    {
        void Add(RTC_TaskList task);
        void Update(RTC_TaskList task);
        void Delete(long id);
        void DeleteMulti(long id);
        RTC_TaskList GetByID(long id);
        void SaveChanges();
        IEnumerable<RTC_TaskList> GetAll(int projectID);
        IEnumerable<RTC_TaskList> GetAll();
        IEnumerable<RTC_TaskList> GetOthersColumn(int projectID, int? order, int? current);
    }
}
