using CuabProjectAllocation.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Validators
{
    public class ProfileCreationValidator: AbstractValidator<StaffProfileDto>
    {
        public ProfileCreationValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.FullName).NotEmpty();
            RuleFor(p => p.MobileNumber).NotEmpty();    
            RuleFor(p => p.Department).NotEmpty();
            RuleFor(p => p.Gender).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.UserType).NotNull();
        }
    }
}
