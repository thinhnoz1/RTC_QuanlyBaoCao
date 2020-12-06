using Microsoft.VisualStudio.TestTools.UnitTesting;
using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Data.Repositories;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.UnitTest.RepositoryTest
{
    [TestClass]
    public class AccountRepositoryTest
    {
        IDbFactory dbFactory;
        IAccountRepository accountRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            accountRepository = new AccountRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void AccountRepository_Create()
        {
            RTC_Account account = new RTC_Account();
            account.Email = "test";
            account.Password = "test";
            account.AccountType = 1;
            account.Status = true;
            account.UserID = 1;

            accountRepository.Add(account);

            var result = accountRepository.Add(account);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.AccountID);
        }

        [TestMethod]
        public void AccountRepository_GetAll()
        {
            var list = accountRepository.GetAll().ToList();
            Assert.AreEqual(5, list.Count);
        }
    }
}
