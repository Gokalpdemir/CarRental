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
    public class ColorDtoValidator:AbstractValidator<ColorDto>
    {
        public ColorDtoValidator() 
        { 
            RuleFor(c=>c.Name).NotEmpty();
            RuleFor(c => c.Name).Must(ValidColorName).WithMessage(Messages.ColorNameMustContainOnlyLetter);
            RuleFor(c => c.Name).MinimumLength(2);
        }

        private bool ValidColorName(string arg)
        {
           return !arg.Any(char.IsDigit);
        }
    }
}
