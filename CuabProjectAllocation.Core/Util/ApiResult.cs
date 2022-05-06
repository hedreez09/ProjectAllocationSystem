using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Util
{
    public class ApiResult<T>: ApiResult
    {
        public T data { get; set; }
    }

    public class ApiResult
    {
        public ApiResult()
        {
            timeGenerated = DateTime.Now;
            eventId = helper.GenerateRadomNumber().ToString();            
        }
        public ErrorResponse error { get; set; }
        public bool hasMessage { get; set; }    
        public int requestStatus { get; set; }
        public DateTime  timeGenerated { get; set; }
        public string eventId { get; set; }
    }

    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
    }
}
