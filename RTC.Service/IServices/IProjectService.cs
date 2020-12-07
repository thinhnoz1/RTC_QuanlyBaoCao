using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.IServices
{
    public interface IProjectService
    {
        void Add(RTC_Project project);
        void Update(RTC_Project project);
        void Delete(RTC_Project project);
        void Delete(int id);
        IEnumerable<RTC_Project> GetAll();
        IEnumerable<RTC_Project> GetAll(string keyword);
        IEnumerable<RTC_Project> GetAllPaging(int page, int pageSize, out int totalRow);
        RTC_Project GetByProjectID(int id);
        IEnumerable<RTC_Project> GetAllWiithInfoPaging(int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
}
