using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Util
{
    public class AppSettings
    {
        public string MaxPasswordTries { get; set; }

        public string CuabSmtpEmail { get; set; }
        public string CuabSmtpServer { get; set; }
        public int CuabSmtpPort { get; set; }
        public string CuabSmptUsername { get; set; }
        public string CuabSmtpPassword { get; set; }
        public string Dev_Env { get; set; }
    }
}
