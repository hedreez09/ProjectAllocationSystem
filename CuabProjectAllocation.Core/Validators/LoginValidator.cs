using CuabProjectAllocation.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Validators
{
    public class LoginValidator: AbstractValidator<LoginRequestDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.password).NotEmpty();
            RuleFor(x => x.username).NotEmpty();
        }
    }
}
