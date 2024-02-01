﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var isAvailable = _rentalDal.GetAll(p=>p.CarId==rental.CarId &&p.ReturnDate==null).Any();
            if (isAvailable == true)
            {
                return new ErrorResult(Messages.CarIsNotAvailable);

            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            
        }

        public IResult Delete(Rental rental)
        {
            
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id), Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
           _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
            

        }
    }
}
