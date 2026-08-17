using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Controllers
{
    public class AdminControllerBase : Controller //ensures that controller functionality is only accessible after login/authentication.
                                                  //this acts as a prerequisite for all controllers that inherit from it,
                                                  //enforcing a consistent access control mechanism across the application.
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUsername")))
            {
                context.HttpContext.Items["AccessDenied"] = true; // signals redirect reason
                context.Result = new RedirectToActionResult("Login", "Access", null); //goes to login page in the access folder. follows in that order.

                TempDataDictionaryFactory tempDataFactory = (TempDataDictionaryFactory)context.HttpContext.RequestServices.GetRequiredService<ITempDataDictionaryFactory>();
                var tempData = tempDataFactory.GetTempData(context.HttpContext); //fetches the TempData dictionary for the current request context, allowing for temporary data storage across requests.
                tempData["AccessError"] = "You must be logged in as an admin to access that page.";
                //error message will be displayed on the login page
                return;
            }
        }
    }
}
