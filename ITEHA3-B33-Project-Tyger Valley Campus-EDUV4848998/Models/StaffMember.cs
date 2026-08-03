namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Models
{
    public class StaffMember
    {
        public required int StaffId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string Position { get; set; }
        public string Unit { get; set; }

        public StaffMember(int staffId, string fullName, string email, string position, string unit)
        {
            StaffId = staffId;
            FullName = fullName;
            Email = email;
            Position = position;
            Unit = unit;
        }

        public string GetStaffDetails()
        {
            return $"Staff ID: {StaffId}, Name: {FullName}, Email: {Email}, Position: {Position}, Unit: {Unit}";
        }
          
        
    }
}
