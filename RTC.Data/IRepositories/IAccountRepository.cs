using RTC.Data.Infrastructure;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.IRepositories
{
    public interface IAccountRepository : IRepository<RTC_Account>
    {
        RTC_Account GetByEmail(string email);
        IEnumerable<RTC_Account> GetAllWithInfo(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<RTC_Account> ListAllPaging(int page, int pageSize);
        IEnumerable<RTC_Account> ListAllPaging(string searchString, int page, int pageSize);
    }
}
