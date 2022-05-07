using CuabProjectAllocation.Core.DTO;
using CuabProjectAllocation.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Interface
{
    public interface IStudentService
    {
        Task<Tuple<bool, ErrorResponse>> StudentAccountCreation(StaffProfileDto request, string ipAddress);
    }
}
