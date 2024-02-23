using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Security.Hashing;
using Business.Security.JWT;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;

using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        IMapper _mapper;
        public AuthManager(IUserService  userService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userService=userService;
            _tokenHelper=tokenHelper;
            _mapper=mapper;
        }
        
        
        
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {           
            var claims = _userService.GetClaims(_mapper.Map<UserDto>(user));
           var accessToken= _tokenHelper.CreateToken(user,_mapper.Map<List<OperationClaim>>(claims.Data));
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck =_userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new SuccessDataResult<User>(_mapper.Map<User>(userToCheck.Data),Messages.SuccessFulLogin);
            }
            return new ErrorDataResult<User>(Messages.PasswordError);
        }

        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            
                byte[] passwordHash, passwordsalt;
                HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out  passwordHash,out passwordsalt);
                UserDto user = new UserDto
                {
                    FirstName = userForRegisterDto.FirstName,
                    Email = userForRegisterDto.Email,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordsalt,
                    Status=true
                };
                _userService.Add(user);
                return new SuccessDataResult<User>(_mapper.Map<User>(user),Messages.UserRegistered);
            
        }


        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Success)
            {
                return new  SuccessResult(Messages.UserAlreadyExists);
            }
            return new ErrorResult();
        }
       
    }
}
