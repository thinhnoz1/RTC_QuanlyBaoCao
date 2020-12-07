using RTC.Common.Common;
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
        
        // GET: Login
        public ActionResult Login()
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
                    var userSession = new AccountLogin();
                    userSession.Email = user.Email;
                    userSession.AccountID = user.AccountID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    ModelState.AddModelError("", "Đăng nhập thành công!!");

                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản sai hoặc không tồn tại!");
                }
            }
            return View("Login");
        }
    }
}