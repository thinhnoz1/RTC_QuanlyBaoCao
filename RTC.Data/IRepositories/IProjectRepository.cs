using RTC.Data.Infrastructure;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.IRepositories
{
    public interface IProjectRepository : IRepository<RTC_Project>
    {
        IEnumerable<RTC_Project> GetByProjectID (int id);
        IEnumerable<RTC_Project> ListAllPaging(int page, int pageSize);
        IEnumerable<RTC_Project> ListAllPaging(string searchString, int page, int pageSize);
    }
}
