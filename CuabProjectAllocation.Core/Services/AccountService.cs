﻿using CuabProjectAllocation.Core.DTO;
using CuabProjectAllocation.Core.Exceptions;
using CuabProjectAllocation.Core.Interface;
using CuabProjectAllocation.Core.Util;
using CuabProjectAllocation.Core.Validators;
using CuabProjectAllocation.Infrastructure.DAC;
using CuabProjectAllocation.Infrastructure.Entities;
using CuabProjectAllocation.Infrastructure.Enums;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.Extensions.Options;
using System.Runtime.Caching;
using System.Security.Claims;
using System.Collections.Generic;

namespace CuabProjectAllocation.Core.Services
{
    public class AccountService: IAccountService
    {
        private readonly IEntityRepository<ApplicationUser> _appUserRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Lecturer> _LecturerRepository;
        private readonly IOptions<AppSettings> _appSettings;

        public AccountService(IEntityRepository<ApplicationUser> appUserRepository, IEntityRepository<Student> studentRepository, IOptions<AppSettings> appSettings, IEntityRepository<Lecturer> lecturerRepository)
        {
            _appUserRepository = appUserRepository;
            _studentRepository = studentRepository;
            _appSettings = appSettings;
            _LecturerRepository = lecturerRepository;
        }
       

        public async Task<Tuple<UserResponseDto, ErrorResponse>> ValidateCredential(string username, string password)
        {
            ErrorResponse errorResponse = new ErrorResponse();
            var validationResult = new UserResponseDto();

            try
            {
                var userObj = await _appUserRepository.GetByAsync(x => x.Username == username && !x.IsDeleted);
                if (userObj == null)
                    throw new CustomException("Invalid Login Details");                              

                if (!userObj.Status || userObj.LockoutEnabled)
                    throw new CustomException("Your profile is not active, kindly contact admin");

                if (userObj.AccountConfirmationStatus == RegistrationStatusEnum.Pending)
                    throw new CustomException("Your account is yet to be activated, kindly check your email");

                int maxPasswordTrials = Convert.ToInt32(_appSettings.Value.MaxPasswordTries);

                if (userObj.FailedLoginCount > maxPasswordTrials)
                {
                    userObj.LockoutEnabled = true;  
                    _appUserRepository.Update(userObj);
                    throw new CustomException("Password trials exceeded, kindly contact admin for assistance");
                }

                var isLoginValid = BCrypt.Net.BCrypt.Verify(password, userObj.PasswordHash);
                if (!isLoginValid)
                {
                    userObj.FailedLoginCount++;
                    _appUserRepository.Update(userObj);

                    int triaLeft = maxPasswordTrials - userObj.FailedLoginCount;
                    throw new CustomException($"Invalid login Details. You have {triaLeft} more attempt(s)");
                }

                if(userObj.FailedLoginCount > 0)
                {
                    userObj.FailedLoginCount = 0;
                    _appUserRepository.Update(userObj);
                }

                userObj.LastLoginTime = DateTime.Now;
                userObj.ModifiedBy = username;
                _appUserRepository.Insert(userObj);

                if(userObj.UserType == UserType.Student)
                    validationResult = await GetStudentInfo(username);

                if(userObj.UserType == UserType.Staff)
                    validationResult = await GetStaffInfo(username);               
                                
                try
                {
                    ObjectCache cache = MemoryCache.Default;
                    if (cache[userObj.Username + "_lastLoginDate"] != null)
                        cache.Remove(userObj.Username + "_lastLoginDate");

                    //Create a custom Timeout of 1day
                    CacheItemPolicy policy = new CacheItemPolicy()
                    {
                        AbsoluteExpiration = DateTime.Now.AddDays(1)
                    };

                    //Cache the response
                    cache.Add(userObj.Username + "_lastLoginDate", userObj.LastLoginTime.ToString(), policy);
                }
                catch (Exception ex) { ex.ToString(); }
            }
            catch(CustomException ex)
            {
                errorResponse.Errors.Add(ex.Message);
            }
            catch(Exception ex)
            {
                ex.ToString();
                errorResponse.Errors.Add("Oops...something went wrong, pls try again");
            }

            return new Tuple<UserResponseDto, ErrorResponse>(validationResult, errorResponse);
        }

        public Claim[] SetUserClaims(UserResponseDto claimsObj)
        {
            var userClaims = new List<Claim>()
            {
                new Claim(UserClaimTypes.Department, claimsObj.Department),
                new Claim(UserClaimTypes.Username, claimsObj.Username),
                new Claim(UserClaimTypes.Email, claimsObj.Email),
                new Claim(UserClaimTypes.PhoneNumber, UserClaimTypes.PhoneNumber),
                new Claim(UserClaimTypes.Gender, UserClaimTypes.Gender),
                new Claim(UserClaimTypes.FullName, UserClaimTypes.FullName)
            };

            return userClaims.ToArray();
        }

        private async Task<UserResponseDto> GetStudentInfo(string username)
        {
            var result = new UserResponseDto();

            var studentInfo = await _studentRepository.GetByAsync(x => x.MatricNumber == username);
            if (studentInfo != null)
            {
                result.FullName = studentInfo.FullName;
                result.Gender = studentInfo.Gender;
                result.Department = studentInfo.Department;
                result.PhoneNumber = studentInfo.PhoneNumber;
                result.Email = studentInfo.Email;
            }

            return result;
        }

        private async Task<UserResponseDto> GetStaffInfo(string username)
        {
            var result = new UserResponseDto();

            var staffInfo = await _LecturerRepository.GetByAsync(x => x.StaffId == username);
            if(staffInfo != null)
            {
                result.FullName = staffInfo.FullName;
                result.PhoneNumber = staffInfo.PhoneNumber;
                result.Gender = staffInfo.Gender;
                result.Department = staffInfo.Department;
                result.Email = staffInfo.Email;
            }

            return result;
        }
    }
}