using ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Services;

using Microsoft.AspNetCore.Mvc;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Controllers
{
    public class AccessController : Controller
    {
        
        private readonly AdminService _adminService;
        public AccessController(AdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUsername")))
                return RedirectToAction("Index", "Staff");

            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_adminService.ValidateCredentials(username, password))
            {
                HttpContext.Session.SetString("AdminUsername", username); 
                return RedirectToAction("Index", "Staff"); 
            }

            TempData["AccessError"] = "Invalid username or password.";
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
