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
        public string StaffId { get; set; }
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
}
