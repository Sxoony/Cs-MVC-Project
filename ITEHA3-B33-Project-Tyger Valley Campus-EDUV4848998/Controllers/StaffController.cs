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

        public IActionResult Index(Guid? searchId)
        {
            var allStaff = _staffService.GetAllStaffMembers();
            ViewBag.SearchId = searchId;

            if (searchId.HasValue)
            {
                ViewBag.SearchResult = _staffService.GetStaffById(searchId.Value);
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
        public IActionResult Edit(Guid id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff==null)  return NotFound();
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
        public IActionResult Delete(Guid id)
        {
            if (_staffService.DeleteStaffMember(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
