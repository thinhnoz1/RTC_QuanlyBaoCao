﻿using RTC.Common.Common;
using RTC.Model.Models;
using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTC.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IEmployeeService employeeService;
        public LoginController(IAccountService _accountService, IEmployeeService _employeeService)
        {
            this.accountService = _accountService;
            this.employeeService = _employeeService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            
            if (ModelState.IsValid)
            {
                var result = accountService.Login(model.Email, Encryptor.EncodePasswordToBase64(model.Password));
                if (result == 1)
                {
                    var user = accountService.GetByEmail(model.Email);

                    var employee = employeeService.GetByID(user.UserID);
                    var userSession = new AccountLogin();
                    userSession.Email = user.Email;
                    userSession.AccountID = user.AccountID;
                    userSession.UserID = user.UserID;
                    userSession.FullName = employee.FullName;
                    userSession.AccountType = user.AccountType;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    if (user.AccountType == 2)
                        return RedirectToAction("Index", "ProjectManager");
                    else
                        return RedirectToAction("Index", "ReportAdmin", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản sai hoặc không tồn tại!");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }
    }
}