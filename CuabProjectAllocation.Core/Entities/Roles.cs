using CuabProjectAllocation.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Entities
{
    public class Roles: Entity<Guid>
    {
        public string Name { get; set; }
    }
}
