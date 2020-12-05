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
    public class AccountRepository : RepositoryBase<RTC_Account>, IAccountRepository
    {
        public AccountRepository(DbFactory dbFactory) : base(dbFactory)
        {
            
        }

        public IEnumerable<RTC_Account> GetByEmail(string email)
        {
            return this.DbContext.RTC_Accounts.Where(x => x.Email == email);
        }
    }
}
