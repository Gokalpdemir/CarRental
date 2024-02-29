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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        IMapper _mapper;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public BrandManager(IBrandDal brandDal,IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(BrandDtoValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(BrandDto brandDto)
        {
            _brandDal.Add(_mapper.Map<Brand>(brandDto));
            return new SuccessResult(Messages.Added);
        }
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(BrandDto brandDto)
        {
           _brandDal.Delete(_mapper.Map<Brand>(brandDto));
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<BrandDto>> GetAll()
        {
           return new SuccessDataResult<List<BrandDto>>(_mapper.Map<List<BrandDto>>(_brandDal.GetAll()),Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<BrandDto> GetById(int id)
        {
            return new SuccessDataResult<BrandDto>(_mapper.Map<BrandDto>(_brandDal.Get(p => p.Id == id)), Messages.Listed);
        }

        [ValidationAspect(typeof(BrandDtoValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(BrandDto brandDto)
        {
            _brandDal.Update(_mapper.Map<Brand>(brandDto));
            return new SuccessResult(Messages.Updated);
        }
    }
}
