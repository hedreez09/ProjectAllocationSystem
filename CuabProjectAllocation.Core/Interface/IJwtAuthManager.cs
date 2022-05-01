using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Interface
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);
        JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);
    }
}
