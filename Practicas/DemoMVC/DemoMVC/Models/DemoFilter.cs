using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Models
{
    public class DemoFilter : ActionFilterAttribute
    {
        private string x;
        public DemoFilter()
        {

        }
        public DemoFilter(string x)
        {
            this.x = x;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}