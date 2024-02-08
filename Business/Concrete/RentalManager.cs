using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IMapper _mapper;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public RentalManager(IRentalDal rentalDal,IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(RentalDtoValidator))]
        public IResult Add(RentalDto rentalDto)
        {
            var isAvailable = _rentalDal.GetAll(p=>p.CarId== rentalDto.CarId &&p.ReturnDate==null).Any();
            if (isAvailable == true)
            {
                return new ErrorResult(Messages.CarIsNotAvailable);

            }
            else
            {
                _rentalDal.Add(_mapper.Map<Rental>(rentalDto));
                return new SuccessResult(Messages.Added);
            }
            
        }

        public IResult Delete(RentalDto rentalDto)
        {
            
            _rentalDal.Delete(_mapper.Map<Rental>(rentalDto));
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<RentalDto>> GetAll()
        {
            return new SuccessDataResult<List<RentalDto>>(_mapper.Map<List<RentalDto>>(_rentalDal.GetAll()),Messages.Listed);
        }

        public IDataResult<RentalDto> GetById(int id)
        {
            return new SuccessDataResult<RentalDto>(_mapper.Map<RentalDto>(_rentalDal.Get(p => p.Id == id)), Messages.Listed);
        }

        [ValidationAspect(typeof(RentalDtoValidator))]
        public IResult Update(RentalDto rentalDto)
        {
           _rentalDal.Update(_mapper.Map<Rental>(rentalDto));
            return new SuccessResult(Messages.Updated);
            

        }
    }
}
