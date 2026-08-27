using ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Services;

using Microsoft.AspNetCore.Mvc;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Controllers
{
    public class AccessController : Controller
    {



        // =========== DELIVERABLE 3 ===========

        //normal controller, not api driven. This is to properly establish a connection and be able to communicate with HTTP requests and responses for the Views.
        //API controllers are used for RESTful APIs, which is not the case here.
        //This controller is used to handle access control for the admin user. Not the staff members.
        //I learned this the hard way.

        private readonly IAdminService _adminService;
        public AccessController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View(); //landnig page.
        }


        [HttpGet] //Get request to navigate to the login page.
                  //POST is not used because data is not being sent to the server, only a request to view the page.
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUsername"))) //variable name so that admin credentials can change without needing this code to change too.
                return RedirectToAction("Index", "Staff"); //return the view for the staff controller index page if the admin is already logged in. This prevents the admin from logging in again and overwriting the session variable.

            return View(); 
        }

       
        [HttpPost]
        public IActionResult Login(string username, string password) //username and password is fetched from the form in the view. That is why a variable isnt necessary to pass through POST.
        {
            if (_adminService.ValidateCredentials(username, password))
            {
                HttpContext.Session.SetString("AdminUsername", username); 
                return RedirectToAction("Index", "Staff"); 
            }

            TempData["AccessError"] = "Invalid username or password."; //display error message if login fails.
                                                                       //Data is stored in TempData to be accessed later. Persists only for one request.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
