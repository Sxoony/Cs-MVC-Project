using System.ComponentModel.DataAnnotations;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Models
{
    //public interface IStaffMember
    //{
    //only needed if want to use staff members and system admins interchangably in the future, which is not the case for this project.
    //}



    // =========== DELIVERABLE 1 ===========



    public class StaffMember
    {
        [Key]
        public Guid StaffId { get; set; }

        [Required(ErrorMessage = "Full Name is required.")] //server side validation beyond javascript.
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Please enter a valid email address (e.g. name@example.com).")]
        public string Email { get; set; }
        public string Position { get; set; }       
        public string Unit { get; set; } //unit is not explicitly described, but it is assumed to be the department or division the staff member belongs to. Natural string data type.

        public StaffMember(string fullName, string email, string position, string unit)
        { 
            FullName = fullName;
            Email = email;
            Position = position;
            Unit = unit;
        }
        public StaffMember()
        {
        }
        public string GetStaffDetails()
        {
            return $"Staff ID: {StaffId}, Name: {FullName}, Email: {Email}, Position: {Position}, Unit: {Unit}";
        }
        //plain data holder for showing staff info, mirroring staff class.
        
    }
}
