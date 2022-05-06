using CuabProjectAllocation.Core.DTO;
using CuabProjectAllocation.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Interface
{
    public interface IUserService
    {
        Task<Tuple<bool, ErrorResponse>> StudentAccountCreation(StaffProfileDto request, string ipAddress);
        Task<Tuple<UserResponseDto, ErrorResponse>> ValidateCredential(string username, string password);
        Claim[] SetUserClaims(UserResponseDto claimsObj);
    }
}
