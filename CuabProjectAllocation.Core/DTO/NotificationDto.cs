using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.DTO
{
    public class SendEmailDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recepient { get; set; }
    }
}
