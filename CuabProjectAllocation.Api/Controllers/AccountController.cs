using CuabProjectAllocation.Core.DTO;
using CuabProjectAllocation.Core.Interface;
using CuabProjectAllocation.Core.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, Route("student/create")]
        [ProducesResponseType(typeof(ApiResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> CreateStudentProfile(StaffProfileDto payload)
        {
            var result = new ApiResult();
            var resp = await _userService.StudentAccountCreation(payload, ClientIP);
            if(resp.Item1)
            {
                result.requestStatus = 200;
                result.message = "Record Uploaded Successfully";   
                return Ok(result);
            }
            else
            {
                result.requestStatus = 400;
                result.error = resp.Item2;
                result.message = "Error occured!";
                return BadRequest(result);
            }                                   
        }


    }
}
