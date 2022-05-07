using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.Entities
{
    public class ValidationToken: Entity<Guid>
    {
        public string Email { get; set; }
        public string TokenValue { get; set; }
        public DateTime DateGenerated { get; set; }
        public DateTime DateExpired { get; set; }
        public bool IsConsumed { get; set; }
        public DateTime? DateConsumed { get; set; }
    }
}
