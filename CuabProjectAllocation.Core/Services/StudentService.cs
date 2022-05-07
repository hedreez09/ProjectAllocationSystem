using CuabProjectAllocation.Core.DTO;
using CuabProjectAllocation.Core.Exceptions;
using CuabProjectAllocation.Core.Interface;
using CuabProjectAllocation.Core.Util;
using CuabProjectAllocation.Core.Validators;
using CuabProjectAllocation.Infrastructure.DAC;
using CuabProjectAllocation.Infrastructure.Entities;
using CuabProjectAllocation.Infrastructure.Enums;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IEntityRepository<ApplicationUser> _appUserRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Lecturer> _LecturerRepository;

        public StudentService(IEntityRepository<ApplicationUser> appUserRepository, IEntityRepository<Student> studentRepository, IEntityRepository<Lecturer> lecturerRepository)
        {
            _appUserRepository = appUserRepository;
            _studentRepository = studentRepository;
            _LecturerRepository = lecturerRepository;
        }
             

        public async Task<Tuple<bool, ErrorResponse>> StudentAccountCreation(StaffProfileDto request, string ipAddress)
        {
            bool success = false;
            ErrorResponse error = new ErrorResponse();

            try
            {
                var validator = new ProfileCreationValidator();
                ValidationResult validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                    throw new CustomException($"{helper.ResolveFlValidationErrorToStr(validationResult.Errors)}");

                var userObj = await _appUserRepository.GetByAsync(x => x.Username == request.MatricNumber.ToLower()
                                    && x.EmailAddress == request.Email);
                if (userObj != null)
                    throw new CustomException("Matric number/Email exists, kindly check and try again");

                var randomPassword = helper.GenerateRandomNumberV2(8);
                var applicationUser = new ApplicationUser
                {
                    AccountConfirmationStatus = RegistrationStatusEnum.Pending,
                    EmailAddress = request.Email,
                    CreatedBy = request.FullName.ToUpper(),
                    CreatedByIp = ipAddress,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    Status = true,
                    Username = request.MatricNumber.ToLower(),
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(randomPassword),
                    UserType = request.UserType
                };

                var resp = _appUserRepository.Insert(applicationUser);
                if (resp == 0)
                    throw new CustomException("Something went wrong, pls try again later");

                var studentObj = new Student
                {
                    CreatedBy = request.FullName.ToUpper(),
                    CreatedByIp = ipAddress,
                    CreatedDate = DateTime.Now,
                    Department = request.Department,
                    Email = request.Email,
                    FullName = request.FullName,
                    Gender = request.Gender,
                    IsDeleted = false,
                    MatricNumber = request.MatricNumber.ToUpper(),
                    PhoneNumber = request.MobileNumber
                };

                _studentRepository.Insert(studentObj);
                success = true;

                //send email
            }
            catch (CustomException ex)
            {
                error.Errors.Add(ex.Message);
            }
            catch (Exception ex)
            {
                ex.ToString();
                error.Errors.Add("Oops..Something went wrong...pls try again");
            }


            return new Tuple<bool, ErrorResponse>(success, error);
        }
    }
}
