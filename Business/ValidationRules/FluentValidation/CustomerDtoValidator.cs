using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerDtoValidator:AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator() 
        {
            RuleFor(c=>c.CompanyName).NotEmpty();
            RuleFor(c=>c.CompanyName).MinimumLength(2);

        }
    }
}
