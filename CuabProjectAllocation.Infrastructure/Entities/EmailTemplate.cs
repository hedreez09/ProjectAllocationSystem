using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.Entities
{
    public class EmailTemplate: Entity<Guid>
    {
        public string MailType { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
