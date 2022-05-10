using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.Entities
{
    public class LoginHistory: Entity<Guid>
    {
        public string Username { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
