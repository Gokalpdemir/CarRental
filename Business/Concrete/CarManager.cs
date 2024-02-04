using AutoMapper;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IMapper _mapper;

        public CarManager(ICarDal carDal,IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
            
        }

        public IResult Add(CarDto carDto)
        {
            if (carDto.CarName.Length >= 2 && carDto.DailyPrice > 0)
            {
                _carDal.Add(_mapper.Map<Car>(carDto));
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }
               
        }

       

        public IResult Delete(CarDto carDto)
        {
           _carDal.Delete(_mapper.Map<Car>(carDto));
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarDto>> GetAll()
        {
            return new SuccessDataResult<List<CarDto>>(_mapper.Map<List<CarDto>>(_carDal.GetAll()),Messages.Listed);
        }

        public IDataResult<CarDto> GetById(int id)
        {
            return new SuccessDataResult<CarDto>(_mapper.Map<CarDto>(_carDal.Get(p => p.Id == id)),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Listed);
        }

        public IResult Update(CarDto carDto)
        {
            _carDal.Update(_mapper.Map<Car>(carDto));
            return new SuccessResult( Messages.Updated);
            
        }
    }
}
