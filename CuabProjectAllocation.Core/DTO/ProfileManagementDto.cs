using CuabProjectAllocation.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.DTO
{
    public class StaffProfileDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string MatricNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string CreatedBy { get; set; }
    }

    public class LoginRequestDto
    {
        public string username { get; set; }
        public string password { get; set; }    
    }

    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public UserResponseDto UserInfo { get; set; }
    }

    public class UserResponseDto
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MatricNumber { get; set; }
        public string StaffId { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public UserType UserType { get; set; }
    }

    public static class UserClaimTypes
    {        
        public static string FullName { get { return "FullName"; } }
        public static string Username { get { return "Username"; } }
        public static string Department { get { return "Department"; } }
        public static string Gender { get { return "Gender"; } }
        public static string PhoneNumber { get { return "PhoneNumber"; } }
        public static string Email { get { return "Email"; } }
    }

}
