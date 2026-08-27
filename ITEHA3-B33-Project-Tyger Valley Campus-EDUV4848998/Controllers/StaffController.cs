using ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Models;
using ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Controllers
{
    public class StaffController : AdminControllerBase 
    {

        // =========== DELIVERABLE 3 ===========




        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IActionResult Index(string searchId)
        {
            var allStaff = _staffService.GetAllStaffMembers();
            ViewBag.SearchId = searchId; //only lives in current request, so we can use it to pre-fill the search box in the view.

            if (!string.IsNullOrWhiteSpace(searchId))
            {
                if (Guid.TryParse(searchId, out var parsedId))
                {
                    ViewBag.SearchResult = _staffService.GetStaffById(parsedId);
                }
                else
                {
                    ViewBag.InvalidSearchId = true;
                }
            }

            return View(allStaff);
        }



        [HttpGet]
        public IActionResult Create()=> View(new StaffMember("", "", "", "")); //if no staff member is passed, we create a new one with empty fields to avoid null reference exceptions in the view.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.StaffMember staffMember)
        {
            if (!ModelState.IsValid) //if the data from the model binding (according to validation rules) is not valid, we return the view with the current staff member to show validation errors.
            {
                return View(staffMember); // Return the view with validation errors
            }
            _staffService.AddStaffMember(staffMember);
            TempData["SuccessMessage"] = "Staff member created successfully.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string id) //edit can be renamed to anything, the view that references it will still work,
                                             //but it is a good practice to name the action method after the view it returns.
                                             //URLs map automatically to the action method name, so if you change the name of the action method, you will have to change the URL in the view as well.
                                             //This means the asp-action references must match.
        {
            if (!Guid.TryParse(id, out var staffId))
            {
                TempData["SearchError"] = "Invalid Staff ID format.";
                return RedirectToAction("Index");
            }

            var staff = _staffService.GetStaffById(staffId);
            if (staff == null)
            {
                TempData["SearchError"] = $"No staff member found with ID: {id}";
                return RedirectToAction("Index");
            }
            return View(staff);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public IActionResult Edit(Guid id, Models.StaffMember updatedStaff)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedStaff);
            }
          
            if(!  _staffService.UpdateStaffMember(id, updatedStaff)) return NotFound();
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id) //delete is a get request because it is a confirmation page, not the actual deletion action.
        {
            if (!Guid.TryParse(id, out var staffId) || !_staffService.DeleteStaffMember(staffId))
            {
                TempData["SearchError"] = "Invalid Staff ID, or no matching staff member was found.";
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = "Staff member deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
