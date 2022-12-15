using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MoonMarsTravelAgency.Controllers
{
    public class AdminFillter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var admin = filterContext.HttpContext.Session["Admin"];
            if (admin == null)
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Forbidden");
            Debug.WriteLine(filterContext.RequestContext.ToString(), "Action Filter Log ");
        }
    }

    public class UserFillter : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            var id = filterContext.HttpContext.Session["ID"];
            if (id == null)
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Forbidden");



            Debug.WriteLine(filterContext.RequestContext.ToString(), "Action Filter Log ");
        }
    }
}