
namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Services
{
    public class StaffService : IStaffService
    {


        // =========== DELIVERABLE 2 ===========

        //Controllers will never see this service class, it is only used to access the manipulated data (from the business logic).

        private readonly List<Models.StaffMember> _staffMembers; //in-memory private list of staff members, can be replaced with database in future if needed. Private list to hide information to methods outside of the class.
        public StaffService()
        {
            _staffMembers = new List<Models.StaffMember>();
        } //new initialized list of staff members, can be replaced with database in future if needed.
        public Models.StaffMember AddStaffMember(Models.StaffMember staffMember)
        {
                staffMember.StaffId=Guid.NewGuid(); //user should never be able to manually insert id. Alternatives are to auto-increment id or use a guid. I chose guid because it is more secure and unique. Auto-increment id can be guessed and is not unique across different databases.
            _staffMembers.Add(staffMember);
            return staffMember;
        }
        public IEnumerable<Models.StaffMember> GetAllStaffMembers()
        {
            return _staffMembers;
        }

        public Models.StaffMember? GetStaffById(Guid Id) //nullable for data validation and error handling.
        {
           return _staffMembers.Find(staff => staff.StaffId == Id);
        }

        public bool UpdateStaffMember(Guid Id, Models.StaffMember updatedStaff)
        {
            var exists = GetStaffById(Id);
            if (exists == null) return false;
            exists.FullName = updatedStaff.FullName;
            exists.Email= updatedStaff.Email;
            exists.Position= updatedStaff.Position;
            exists.Unit= updatedStaff.Unit;
            return true;
        } //updates staff member information if it exists in the list, returns simple boolean.

        public bool DeleteStaffMember(Guid Id)
        {
            var staffMember = GetStaffById(Id);
            if (staffMember == null) return false;
            _staffMembers.Remove(staffMember);
            return true; //deletes staff member if it exists in the list, returns simple boolean.
        }

    }
}
