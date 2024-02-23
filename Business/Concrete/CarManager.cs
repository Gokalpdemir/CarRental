using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IMapper _mapper;

        public CarManager(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }
        [ValidationAspect(typeof(CarDtoValidator))]
        [SecuredOperation("Admin")]
        public IResult Add(CarDto carDto)
        {
           
                ValidationTool.Validate(new CarDtoValidator(), carDto);
                _carDal.Add(_mapper.Map<Car>(carDto));
                return new SuccessResult(Messages.Added);
        }



        public IResult Delete(CarDto carDto)
        {
            _carDal.Delete(_mapper.Map<Car>(carDto));
            return new SuccessResult(Messages.Deleted);
        }

        
        public IDataResult<List<CarDto>> GetAll()
        {
            return new SuccessDataResult<List<CarDto>>(_mapper.Map<List<CarDto>>(_carDal.GetAll()), Messages.Listed);
        }

        public IDataResult<CarDto> GetById(int id)
        {
            return new SuccessDataResult<CarDto>(_mapper.Map<CarDto>(_carDal.Get(p => p.Id == id)), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        [ValidationAspect(typeof(CarDtoValidator))]


        public IResult Update(CarDto carDto)
        {
            _carDal.Update(_mapper.Map<Car>(carDto));
            return new SuccessResult(Messages.Updated);

        }
    }
}
