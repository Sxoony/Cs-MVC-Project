using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Controllers
{
    public class AdminControllerBase : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUsername")))
            {
                context.HttpContext.Items["AccessDenied"] = true; // signals redirect reason
                context.Result = new RedirectToActionResult("Login", "Access", null);

                TempDataDictionaryFactory tempDataFactory = (TempDataDictionaryFactory)context.HttpContext.RequestServices.GetRequiredService<ITempDataDictionaryFactory>();
                var tempData = tempDataFactory.GetTempData(context.HttpContext);
                tempData["AccessError"] = "You must be logged in as an admin to access that page.";
                //error message will be displayed on the login page
                return;
            }
        }
    }
}
