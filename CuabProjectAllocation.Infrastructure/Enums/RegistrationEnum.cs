using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.Enums
{
    public enum RegistrationStatusEnum
    {
        Pending = 1,
        Activated
    }

    public enum UserType
    {
        Student = 1,
        Staff,
        Admin,
        SuperAdmin
    }
}
