using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RTC.Service.IServices
{
    public interface IEmployeeService
    {
        void Add(RTC_Employee employee);
        void Update(RTC_Employee employee);
        void Delete(int id);
        IEnumerable<RTC_Employee> GetAll();
        IEnumerable<RTC_Employee> ListAllPaging(int page, int pageSize);
        IEnumerable<RTC_Employee> ListAllPaging(string searchString, int page, int pageSize);
        void SaveChanges();
    }
}
