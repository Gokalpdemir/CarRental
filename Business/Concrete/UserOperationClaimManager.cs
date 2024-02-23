using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Business;
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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        IMapper _mapper;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _mapper = mapper;
        }

       

        public IDataResult<List<UserOperationClaimDto>> GetAll()
        {
            var result =_userOperationClaimDal.GetAll();
            if(result == null)
            {
                return new ErrorDataResult<List<UserOperationClaimDto>>(Messages.Error);
            }
            return new SuccessDataResult<List<UserOperationClaimDto>>(_mapper.Map<List<UserOperationClaimDto>>(result));
        }

        public IDataResult<UserOperationClaimDto> GetById(int UserOperationClaimId)
        {
            var result = BusinessRules.Run(checkUserOperationClaim(UserOperationClaimId));
            if (result != null)
            {
                return new ErrorDataResult<UserOperationClaimDto>(result.Message);
            }
            return new SuccessDataResult<UserOperationClaimDto>(_mapper.Map<UserOperationClaimDto>(_userOperationClaimDal.Get(uoc=>uoc.Id==UserOperationClaimId)),Messages.Listed);

         
        }
        [SecuredOperation("Admin")]
        public IResult Add(UserOperationClaimDto userOperationClaimDto)
        {
            _userOperationClaimDal.Add(_mapper.Map<UserOperationClaim>(userOperationClaimDto));
            return new SuccessResult(Messages.Added);
        }
        [SecuredOperation("Admin")]
        public IResult Update(UserOperationClaimDto userOperationClaimDto)
        {
            var result = BusinessRules.Run(checkUserOperationClaim(userOperationClaimDto.Id));

            if (result != null)
            {
                return result;
            }
            _userOperationClaimDal.Update(_mapper.Map<UserOperationClaim>(userOperationClaimDto));
            return new SuccessResult(Messages.Updated);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(UserOperationClaimDto userOperationClaimDto)
        {
            var result = BusinessRules.Run(checkUserOperationClaim(userOperationClaimDto.Id));
            if(result != null)
            {
                return result;
            }
            _userOperationClaimDal.Delete(_mapper.Map<UserOperationClaim>(userOperationClaimDto));
            return new SuccessResult(Messages.Deleted);

        }



        private IResult checkUserOperationClaim(int  UserOperationClaimId)
        {
            var result = _userOperationClaimDal.Get(uoc=>uoc.Id == UserOperationClaimId);
            if(result == null)
            {
                return new ErrorResult(Messages.UserOperationClaimNotFound);
            }
            return new SuccessResult();
        }
    }
}
