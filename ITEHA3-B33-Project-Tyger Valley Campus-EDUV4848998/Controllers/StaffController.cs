using ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Models;
using ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Controllers
{
    public class StaffController : AdminControllerBase 
    {
        
        private readonly StaffService _staffService;
        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        public IActionResult Index(string searchId)
        {
            var allStaff = _staffService.GetAllStaffMembers();
            ViewBag.SearchId = searchId;

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
        public IActionResult Create()=> View(new StaffMember("", "", "", ""));
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return View(staffMember);
            }
            _staffService.AddStaffMember(staffMember);
            TempData["SuccessMessage"] = "Staff member created successfully.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string id)
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
        public IActionResult Delete(string id)
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
