using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.IServices
{
    public interface IAccountService
    {
        void Add(RTC_Account account);
        void Update(RTC_Account account);
        void Delete(RTC_Account account);
        void Delete(int id);
        IEnumerable<RTC_Account> GetAll();
        IEnumerable<RTC_Account> GetAll(string keyword);
        IEnumerable<RTC_Account> GetAllPaging(int page, int pageSize, out int totalRow);
        RTC_Account GetByAccountID(int id);
        IEnumerable<RTC_Account> GetAllWiithInfoPaging(int page, int pageSize, out int totalRow);
        void SaveChanges();
        int Login(string email, string password);
        RTC_Account GetByEmail(string email);
    }
}
