using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace ITEHA3_B33_Project_Tyger_Valley_Campus_EDUV4848998.Models
{


    // =========== DELIVERABLE 1 ===========


    public class SystemAdmin
    {
        [Key]
        [Required(ErrorMessage ="Username is required.")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        public SystemAdmin(string username, string password)
        {
            Username = username;
            Password = password;
        }
        //private static string ComputeSha256Hash(string rawData)
        //{
        //    // 1. Convert the input string to a byte array
        //    byte[] inputBytes = Encoding.UTF8.GetBytes(rawData);

        //    // 2. Compute the hash using SHA-256
        //    byte[] hashBytes = SHA256.HashData(inputBytes);

        //    // 3. Convert the byte array back to a readable hexadecimal string
        //    return Convert.ToHexString(hashBytes);
        //} for future adding admins.
        public string GetAdminDetails()
        {
            return $"Username: {Username}";
        }

    }
}
