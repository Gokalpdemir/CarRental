using Business.Constants;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginDtoValidator:AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(u=>u.Email).NotEmpty().WithMessage(Messages.ValidateEmailNotEmpty);
            RuleFor(u=>u.Password).NotEmpty().WithMessage(Messages.ValidatePasswordNotEmpty);
        }
    }
}
