
namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Services
{
    public class StaffService
    {
        private readonly List<Models.StaffMember> _staffMembers; //in-memory list of staff members, can be replaced with database in future if needed.
        public StaffService()
        {
            _staffMembers = new List<Models.StaffMember>();
        } //new initialized list of staff members, can be replaced with database in future if needed.
        public Models.StaffMember AddStaffMember(Models.StaffMember staffMember)
        {
                staffMember.StaffId=Guid.NewGuid(); //user should never be able to manually insert id.
            _staffMembers.Add(staffMember);
            return staffMember;
        }
        public IEnumerable<Models.StaffMember> GetAllStaffMembers()
        {
            return _staffMembers;
        }

        public Models.StaffMember? GetStaffById(Guid Id)
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
        }

        public bool DeleteStaffMember(Guid Id)
        {
            var staffMember = GetStaffById(Id);
            if (staffMember == null) return false;
            _staffMembers.Remove(staffMember);
            return true;
        }

    }
}
