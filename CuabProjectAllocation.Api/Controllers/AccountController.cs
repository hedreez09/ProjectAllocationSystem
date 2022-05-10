using CuabProjectAllocation.Core.Common;
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
                    result.error.Errors.Add(helper.ResolveFlValidationErrorToStr(validationResult.Errors));
                    result.responseCode = Constants.InputValidationError;
                    return BadRequest(result);
                }

                var validateCredentials = await _userService.ValidateCredential(request.username, request.password);
                if(validateCredentials.Item2 != null)
                {
                    var errorMsg = validateCredentials.Item2;                    
                    result.error = errorMsg;
                    result.responseCode = Constants.ErrorOccured;
                    return BadRequest(result);
                }

                var isPasswordReset = await _userService.ActivatePasswordReset(request.username);
                if (isPasswordReset)
                {
                    result.responseCode = Constants.ResetPassword;
                    return Ok(result);
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
                result.responseCode = Constants.Successful;               
                return Ok(result);

            }
            catch(Exception ex)
            {
                ex.ToString();                
                result.error.Errors.Add("Ooops!! Something went wrong, pls try again");
                result.responseCode = Constants.SomethingWentWrong;
                return BadRequest(result);
            }
        }


        [HttpGet, Route("confirm")]
        public async Task<IActionResult> AccountConfirmation(string email)
        {
            return Ok();
        }


    }
}
