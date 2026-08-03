using ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Models;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Services
{
    public class AdminService
    {
        private readonly List<SystemAdmin> _admins = new()
        {
            new SystemAdmin("admin", "Admin123")
        };
        public bool ValidateCredentials(string username, string password)
        {
            return _admins.Any(a => a.Username == username && a.Password == password);
        }
       
    }
}
