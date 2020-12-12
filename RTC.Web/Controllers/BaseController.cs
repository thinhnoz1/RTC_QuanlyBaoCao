using RTC.Common.Common;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RTC.Web.Controllers
{
    public class BaseController : Controller, IDisposable
    {

        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (AccountLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index"}));
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            var controller = requestContext.RouteData.Values["controller"].ToString().Trim().ToUpper();
            var action = requestContext.RouteData.Values["action"].ToString().Trim().ToUpper();
            var area = requestContext.RouteData.DataTokens["area"] == null ? "WEB" : requestContext.RouteData.DataTokens["area"].ToString().Trim().ToUpper();

            if (PublicControllers.Contains(controller.ToUpper()))
            {
            }
            else
            {
                //if (area != "TRAINING")
                //{
                //    ServiceHelper.Set(EService.Training.GetHashCode());
                //    requestContext.HttpContext.Response.Redirect("/Training");
                //}
            }

            base.Initialize(requestContext);
        }
        protected internal virtual RTC.Web.Models.AjaxResult AjaxResult(bool isSuccess = true, string message = "", object json = null, string debugMessage = "", bool allowGet = true)
        {
            return new RTC.Web.Models.AjaxResult(isSuccess, message, json, debugMessage)
            {
                JsonRequestBehavior = allowGet
                    ? JsonRequestBehavior.AllowGet
                    : JsonRequestBehavior.DenyGet
            };
        }
        private readonly List<string> PublicControllers = new List<string>
        {
            "LOGIN",
            "COMMON"
        };

    }
}