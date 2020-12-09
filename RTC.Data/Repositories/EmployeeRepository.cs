using PagedList;
using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<RTC_Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<RTC_Employee> ListAllPaging(int page, int pageSize)
        {
            return this.DbContext.RTC_Employees.OrderByDescending(x => x.FullName).ToPagedList(page, pageSize);
        }

        public IEnumerable<RTC_Employee> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<RTC_Employee> model = this.DbContext.RTC_Employees;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.FullName.Contains(searchString) || x.Email.Contains(searchString)).OrderBy(x => x.FullName);
            }
            return model.OrderBy(x => x.FullName).ToPagedList(page, pageSize);
        }
    }
}
