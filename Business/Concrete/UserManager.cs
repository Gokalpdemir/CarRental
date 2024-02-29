using AutoMapper;
using Business.Abstract;
using Business.AutoMappers;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public UserManager(IUserDal userDal,IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public IResult Add(UserDto userDto)
        {
           _userDal.Add(_mapper.Map<User>(userDto));
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UserDto userDto)
        {
            _userDal.Delete(_mapper.Map<User>(userDto));
            return new SuccessResult(Messages.Deleted);
        }

       
        public IDataResult<List<UserDto>> GetAll()
        {
            return new SuccessDataResult<List<UserDto>>(_mapper.Map<List<UserDto>>(_userDal.GetAll()),Messages.Listed);
        }

        
        public IDataResult<UserDto> GetById(int id)
        {
          
            return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(_userDal.Get(p => p.Id == id)), Messages.Listed);
        }

        
        public IDataResult<UserDto> GetByMail(string email)
        {
            var user =_userDal.Get(u=>u.Email == email);
            if(user == null)
            {
                return new ErrorDataResult<UserDto>(Messages.UserNotFound);     
            }
           return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(user));
        }

        public IDataResult<List<OperationClaim>> GetClaims(UserDto userDto)
        {

            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(_mapper.Map<User>(userDto)),Messages.Listed);
        }

        [ValidationAspect(typeof(UserDtoValidator))]
        public IResult Update(UserDto userDto)
        {
            _userDal.Update(_mapper.Map<User>(userDto));
            return new SuccessResult(Messages.Updated);
        }
    }
}
