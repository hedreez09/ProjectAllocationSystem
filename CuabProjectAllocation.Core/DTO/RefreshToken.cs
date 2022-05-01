using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.DTO
{
    public class RefreshToken
    {
        public string Username { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
