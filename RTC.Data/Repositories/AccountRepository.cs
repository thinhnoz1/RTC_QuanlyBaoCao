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
    public class AccountRepository : RepositoryBase<RTC_Account>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }

        public IEnumerable<RTC_Account> GetAllWithInfo(int pageIndex, int pageSize, out int totalRow)
        {
            var query = from a in DbContext.RTC_Accounts
                        join e in DbContext.RTC_Employees
                        on a.UserID equals e.UserID
                        select a;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }

        public RTC_Account GetByEmail(string email)
        {
            return this.DbContext.RTC_Accounts.SingleOrDefault(x => x.Email == email);
        }
        public IEnumerable<RTC_Account> ListAllPaging(int page, int pageSize)
        {
            return this.DbContext.RTC_Accounts.OrderBy(x => x.AccountID).ToPagedList(page, pageSize);
        }

        public IEnumerable<RTC_Account> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<RTC_Account> model = this.DbContext.RTC_Accounts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Email.Contains(searchString)).OrderBy(x => x.AccountID);
            }
            return model.OrderBy(x => x.AccountID).ToPagedList(page, pageSize);
        }
    }
}
