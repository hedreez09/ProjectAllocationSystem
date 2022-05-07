using CuabProjectAllocation.Core.DTO;
using CuabProjectAllocation.Core.Interface;
using CuabProjectAllocation.Core.Util;
using CuabProjectAllocation.Core.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public AccountController(IAccountService userService, IJwtAuthManager jwtAuthManager)
        {
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }

        [HttpPost, Route("Auth/Login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var result = new ApiResult<LoginResponse>();

            try
            {
                var validator = new LoginValidator();
                ValidationResult validationResult = await validator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    result.hasMessage = true;
                    result.error.Errors.Add(helper.ResolveFlValidationErrorToStr(validationResult.Errors));
                    result.requestStatus = 400;
                    return BadRequest(result);
                }

                var validateCredentials = await _userService.ValidateCredential(request.username, request.password);
                if(validateCredentials.Item2 != null)
                {
                    var errorMsg = validateCredentials.Item2;
                    result.hasMessage = true;
                    result.error = errorMsg;
                    result.requestStatus = 400;
                    return BadRequest(result);
                }

                var userInfo = validateCredentials.Item1;
                var claims = _userService.SetUserClaims(userInfo);
                var jwtResult = _jwtAuthManager.GenerateTokens(request.username, claims, DateTime.Now);
                                
                var loginResult = new LoginResponse
                {
                    AccessToken = jwtResult.AccessToken,
                    ExpiresIn = jwtResult.ExpirationTime,
                    RefreshToken = jwtResult.RefreshToken.ToString(),
                    UserInfo = userInfo
                };

                result.data = loginResult;
                result.requestStatus = 200;               
                return Ok(result);

            }
            catch(Exception ex)
            {
                ex.ToString();
                result.hasMessage = true;
                result.error.Errors.Add("Ooops!! Something went wrong, pls try again");
                result.requestStatus = 400;
                return BadRequest(result);
            }
        }

       


    }
}
