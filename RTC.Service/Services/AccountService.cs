using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.Services
{
    public class AccountService : IAccountService
    {
        IAccountRepository _accountRepository;
        IUnitOfWork _unitOfWork;
        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(RTC_Account account)
        {
            _accountRepository.Add(account);
        }

        public void Delete(int id)
        {
            _accountRepository.Delete(id);
        }

        public void Delete(RTC_Account account)
        {
            _accountRepository.Delete(account);
        }

        public IEnumerable<RTC_Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public IEnumerable<RTC_Account> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                int id = int.Parse(keyword);
                return _accountRepository.GetMulti(x => x.Email.Contains(keyword) || x.UserID.Equals(id));
            }
            else
                return _accountRepository.GetAll();
        }

        public IEnumerable<RTC_Account> GetAllWiithInfoPaging(int page, int pageSize, out int totalRow)
        {
            return _accountRepository.GetAllWithInfo(page, pageSize, out totalRow);
        }

        /* public IEnumerable<RTC_Account> GetAllPaging(int page, int pageSize, out int totalRow)
         {
             throw new NotImplementedException();
         }*/

        public IEnumerable<RTC_Account> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _accountRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public RTC_Account GetByAccountID(int id)
        {
            return _accountRepository.GetSingleById(id);
        }

        public int Login (string email, string password)
        {
            var result = _accountRepository.GetSingleByCondition(x => x.Email == email && x.Password == password);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            };
        }

        public RTC_Account GetByEmail(string email)
        {
            return _accountRepository.GetByEmail(email);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(RTC_Account account)
        {
            _accountRepository.Update(account);
        }
    }
}
