using CuabProjectAllocation.Core.DTO;
using CuabProjectAllocation.Core.Interface;
using CuabProjectAllocation.Core.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CuabProjectAllocation.Core.Common;

namespace CuabProjectAllocation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost, Route("student/create")]
        [ProducesResponseType(typeof(ApiResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> CreateStudentProfile(StaffProfileDto payload)
        {
            var result = new ApiResult<string>();
            var resp = await _studentService.StudentAccountCreation(payload, ClientIP);
            if (resp.Item1)
            {
                result.responseCode = Constants.Successful;
                result.data = "Record Uploaded Successfully";
                return Ok(result);
            }
            else
            {
                result.responseCode = Constants.ErrorOccured;
                result.error = resp.Item2;                
                return BadRequest(result);
            }
        }

       
    }
}
