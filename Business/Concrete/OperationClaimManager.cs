using AutoMapper;
using Business.Abstract;
using Business.AutoMappers;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;
        IMapper _mapper;

       

        public OperationClaimManager(IOperationClaimDal operationClaimDal,IMapper mapper)
        {
            _mapper = mapper;
            _operationClaimDal = operationClaimDal;
            
        }
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
           
            _operationClaimDal = operationClaimDal;

        }

        public IResult Add(OperationClaimDto operationClaimDto)
        {
          var result=  BusinessRules.Run(ClaimAlreadyExists(operationClaimDto));
            if(result != null)
            {
                return result;

            }
            _operationClaimDal.Add(_mapper.Map<OperationClaim>(operationClaimDto));
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(OperationClaimDto operationClaimDto)
        {
            var result =BusinessRules.Run(CheckOperationClaim(operationClaimDto.Id));
            if (result !=null)
            {
                return result;
            }
            _operationClaimDal.Delete(_mapper.Map<OperationClaim>(operationClaimDto));
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<OperationClaimDto> GetById(int claimId)
        {
            var result = BusinessRules.Run(CheckOperationClaim(claimId));
            if(result != null )
            {
                return new ErrorDataResult<OperationClaimDto>(result.Message);
            }
            return new SuccessDataResult<OperationClaimDto>(_mapper.Map<OperationClaimDto>(_operationClaimDal.Get(o => o.Id == claimId)),Messages.Listed);
        }

        public IDataResult<List<OperationClaimDto>> GetAll()
        {
           var result = _operationClaimDal.GetAll();
            if(result != null)
            {
                return new SuccessDataResult<List<OperationClaimDto>>(_mapper.Map<List<OperationClaimDto>>(result),Messages.Listed);
            }
            return new ErrorDataResult<List<OperationClaimDto>>(Messages.Error);
        }

        public IResult Update(OperationClaimDto operationClaimDto)
        {
            var result = BusinessRules.Run(CheckOperationClaim(operationClaimDto.Id));
            if (result != null )
            {
                return new ErrorResult(result.Message);
            }
            _operationClaimDal.Update(_mapper.Map<OperationClaim>(operationClaimDto));
            return new SuccessResult(Messages.Updated);
        }

        private IResult ClaimAlreadyExists(OperationClaimDto operationClaimDto )
        {
            var result = _operationClaimDal.Get(c=>c.Name== operationClaimDto.Name);
            if (result != null)
            {
                return new ErrorResult(Messages.ClaimAlreadyExists);
            }
            return new  SuccessResult();

        }
        private IResult CheckOperationClaim(int operationClaimId)
        {
            var result = _operationClaimDal.Get(o=>o.Id==operationClaimId);
            if (result == null)
            {
                return new ErrorResult(Messages.OperationClaimNotFound);
            }
            return new SuccessResult();

        }
    }
}
