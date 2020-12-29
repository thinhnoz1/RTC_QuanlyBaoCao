using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.IServices
{
    public interface IProjectMemberService
    {
        void Add(RTC_ProjectMember member);
        void Update(RTC_ProjectMember member);
        void Delete(int id);
        void DeleteMulti(int id);
        void DeleteMultiByProjectID(int id);
        RTC_ProjectMember GetByID(int id);
        void SaveChanges();
        List<int> GetUserProject(int userid);
        IEnumerable<RTC_ProjectMember> GetAll(int userID);
        IEnumerable<RTC_ProjectMember> GetAll();
    }
}
