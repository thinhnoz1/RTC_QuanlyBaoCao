using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using RTC.Service.IServices;
using RTC.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.UnitTest.ServiceTest
{
    [TestClass]
    public class AccountServiceTest
    {
        // Su dung Mock de tao doi tuong Repository gia de add

        private Mock<IAccountRepository> mockRepository;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private IAccountService accountService;
        private List<RTC_Account> listAccount;
        [TestInitialize]
        public void Initialize()
        {
            mockRepository = new Mock<IAccountRepository>();
            mockUnitOfWork = new Mock<IUnitOfWork>();
            accountService = new AccountService(mockRepository.Object, mockUnitOfWork.Object);
            listAccount = new List<RTC_Account>()
            {
                new RTC_Account() {Email = "servicetest", Password = "test", AccountType = 1, Status = true, UserID = 1 },
                new RTC_Account() { Email = "servicetest2", Password = "test", AccountType = 1, Status = true, UserID = 1 },
                new RTC_Account() { Email = "servicetest3", Password = "test", AccountType = 1, Status = true, UserID = 1 },

            };
        }

        [TestMethod]
        public void AccountService_GetAll()
        {
            //setup method
            mockRepository.Setup(m => m.GetAll(null)).Returns(listAccount);

            //call action
            var result = accountService.GetAll() as List<RTC_Account>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void AccountService_Create()
        {
            RTC_Account account = new RTC_Account();
            account.Email = "testService";
            account.Password = "test";
            account.AccountType = 1;
            account.Status = true;
            account.UserID = 1;

            mockRepository.Setup(m => m.Add(account)).Returns((RTC_Account p) =>
              {
                  p.AccountID = 1;
                  return p;
              }
            );

            accountService.Add(account);
            
        }
    }
}
