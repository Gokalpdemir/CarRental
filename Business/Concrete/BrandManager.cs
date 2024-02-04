﻿using AutoMapper;
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

        public IResult Add(BrandDto brandDto)
        {
            _brandDal.Add(_mapper.Map<Brand>(brandDto));
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(BrandDto brandDto)
        {
           _brandDal.Delete(_mapper.Map<Brand>(brandDto));
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<BrandDto>> GetAll()
        {
           return new SuccessDataResult<List<BrandDto>>(_mapper.Map<List<BrandDto>>(_brandDal.GetAll()),Messages.Listed);
        }
        
        public IDataResult<BrandDto> GetById(int id)
        {
            return new SuccessDataResult<BrandDto>(_mapper.Map<BrandDto>(_brandDal.Get(p => p.Id == id)), Messages.Listed);
        }

        public IResult Update(BrandDto brandDto)
        {
            _brandDal.Update(_mapper.Map<Brand>(brandDto));
            return new SuccessResult(Messages.Updated);
        }
    }
}
