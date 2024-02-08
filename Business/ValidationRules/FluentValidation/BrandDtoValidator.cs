using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandDtoValidator:AbstractValidator<BrandDto>
    {
        public BrandDtoValidator() 
        { 
            RuleFor(b=>b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
        }
    }
}
