using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthentcionService : IAuthenticationService
    {
        private readonly IUserDal _userDal;
        private readonly ICustomerDal _customerDal;

        public AuthentcionService(IUserDal userDal, ICustomerDal customerDal)
        {
            _userDal = userDal;
            _customerDal = customerDal;
        }

        public IResult RegisterAsCustomer(RegisterAsCustomerDto registerAsCustomerDto)
        {
            User user = new User(); 
            user.FirstName = registerAsCustomerDto.FirstName;
            user.LastName = registerAsCustomerDto.LastName;
            user.Email = registerAsCustomerDto.Email;
            user.Password = registerAsCustomerDto.Password;

            _userDal.Add(user);

            Customer customer = new Customer();
            customer.UserId = user.Id;
            customer.CompanyName = registerAsCustomerDto.CompanyName;

            _customerDal.Add(customer);

            return new SuccessResult(Messages.Added);
        }
    }
}
