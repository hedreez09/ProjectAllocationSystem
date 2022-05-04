using CuabProjectAllocation.Infrastructure;
using System;

namespace CuabProjectAllocation.Infrastructure.Entities
{
    public class Roles: Entity<Guid>
    {
        public string Name { get; set; }
    }
}
