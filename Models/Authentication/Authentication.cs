using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace thuchanh_web_lan1_ngay15_2.Models.Authentication
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("UserName") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {

                        { "Controller", "Login" },
                        { "Action", "Login" }

                    }
                    );
            }
            //base.OnActionExecuting(context);
        }
    }
}

