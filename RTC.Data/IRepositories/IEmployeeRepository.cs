using RTC.Data.Infrastructure;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RTC.Data.IRepositories
{
    public interface IEmployeeRepository : IRepository<RTC_Employee>
    {
        IEnumerable<RTC_Employee> ListAllPaging(int page, int pageSize);
        IEnumerable<RTC_Employee> ListAllPaging(string searchString, int page, int pageSize);
    }
}
