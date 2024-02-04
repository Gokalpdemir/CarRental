using AutoMapper;
using Business.Abstract;
using Business.AutoMappers;
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
            var result = _mapper.Map<UserDto>(_userDal.Get(p => p.Id == id));
            if(result ==null)
            {
                return new ErrorDataResult<UserDto>(Messages.Error);

            }
            return new SuccessDataResult<UserDto>(result,Messages.Listed);
               

            
        }

        public IResult Update(UserDto userDto)
        {
            _userDal.Update(_mapper.Map<User>(userDto));
            return new SuccessResult(Messages.Updated);
        }
    }
}
