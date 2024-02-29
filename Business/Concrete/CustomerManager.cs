using AutoMapper;
using Business.Abstract;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public CustomerManager(ICustomerDal customerDal,IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CustomerDtoValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]

        public IResult Add(CustomerDto customerDto)
        {
            _customerDal.Add(_mapper.Map<Customer>(customerDto));
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(CustomerDto customerDto)
        {
            _customerDal.Delete(_mapper.Map<Customer>(customerDto));
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<CustomerDto>> GetAll()
        {
            return new SuccessDataResult<List<CustomerDto>>(_mapper.Map<List<CustomerDto>>(_customerDal.GetAll()), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<CustomerDto> GetById(int id)
        {
            return new SuccessDataResult<CustomerDto>(_mapper.Map<CustomerDto>(_customerDal.Get(p => p.Id == id)),Messages.Listed);
        }

        [ValidationAspect(typeof(CustomerDtoValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(CustomerDto customerDto)
        {
            _customerDal.Update(_mapper.Map<Customer>(customerDto));
            return new SuccessResult(Messages.Updated);
        }
    }
}
