using Business.Constants;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator:AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).Must(IsLetter).WithMessage(Messages.FirstNameMustContainOnlyLetter);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).Must(IsLetter).WithMessage(Messages.LastNameMustContainOnlyLetter);


            RuleFor(u=>u.Email).NotNull();
            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u=>u.Password).NotEmpty();
            RuleFor(u=>u.Password).MinimumLength(10).Must(IsContainLetter).Must(IsContainDigit).Must(IsContainSpecialCharacter).Must(IsContainUppercaseLetter);

        }

       

        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+$");
            return regex.IsMatch(arg);
        }
        private bool IsContainUppercaseLetter(string arg)
        {
            return arg.Any(char.IsUpper);
        }

        //karakter içeriyor mu kontrol eder
        private bool IsContainLetter(string arg)
        {
            return arg.Any(char.IsLetter);
        }
        //sayı içeriyor mu kontrol eder.
        private bool IsContainDigit(string arg)
        {
            return arg.Any(char.IsDigit);
        }
        //özel karakter içeriyor mu kontrol eder
        private bool IsContainSpecialCharacter(string arg)
        {
            char[] specialCharacters = new char[] { '@', '#', '$', '!', '.', ',', '*', '-', '_', ';', '+', '-', '<', '>' };

            bool isContain = false;
            foreach (var item in specialCharacters)
            {
                if (arg.Contains(item))
                {
                    isContain = true;
                    break;
                }
            };
            return isContain;
        }


        /*
         *    public string Email { get; set; }
          public string Password { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
         */

    }
}
