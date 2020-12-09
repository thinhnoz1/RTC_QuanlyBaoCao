using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace RTC.Web.Models
{
    public class AjaxResult : JsonResult
    {
        public readonly object _json;
        private readonly IList<KeyValuePair<string, object>> _partials;
        private readonly IList<string> _results;

        private readonly bool _isSuccess;
        private readonly string _message, _debugMessage;

        public AjaxResult(bool isSuccess, string message, object json, string debugMessage)
        {
            _isSuccess = isSuccess;
            _message = message;
            _json = json;
            _debugMessage = debugMessage;

            _partials = new List<KeyValuePair<string, object>>();
            _results = new List<string>();
        }

        public AjaxResult WithHtml(string partialViewName = null, object model = null)
        {
            _partials.Add(new KeyValuePair<string, object>(partialViewName, model));
            return this;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            foreach (var partial in _partials)
            {
                var html = RenderPartialToString(context, partial.Key, partial.Value);
                _results.Add(html);
            }
            base.Data = Data;
            base.MaxJsonLength = int.MaxValue;
            base.ExecuteResult(context);
        }

        public new object Data
        {
            get
            {
                return new
                {
                    Html = _results,
                    Json = _json,
                    IsSuccess = _isSuccess,
                    Message = _message,
                    DebugMessage = _debugMessage
                };
            }
        }

        private string RenderPartialToString(ControllerContext context, string viewName, object model)
        {
            var controller = context.Controller;

            var partialView = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);

            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                using (var htmlWriter = new HtmlTextWriter(stringWriter))
                {
                    controller.ViewData.Model = model;
                    partialView.View.Render(
                        new ViewContext(
                            controller.ControllerContext,
                            partialView.View,
                            controller.ViewData,
                            new TempDataDictionary(),
                            htmlWriter),
                        htmlWriter);
                }
            }
            return stringBuilder.ToString();
        }
    }
}