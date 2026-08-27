namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Services
{
    public interface IStaffService
    {
        Models.StaffMember AddStaffMember(Models.StaffMember staffMember);
        IEnumerable<Models.StaffMember> GetAllStaffMembers();
        Models.StaffMember? GetStaffById(Guid Id);
        bool UpdateStaffMember(Guid Id, Models.StaffMember updatedStaff);
        bool DeleteStaffMember(Guid Id);
    }
}
