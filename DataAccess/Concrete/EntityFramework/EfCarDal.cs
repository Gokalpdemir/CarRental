using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDbContext>, ICarDal
    {
        

        public List<CarDetailDto> GetCarDetails()
        {
           using(CarRentalDbContext carRentalDbContext = new CarRentalDbContext())
            {
                var result = from car in carRentalDbContext.Cars
                             join color in carRentalDbContext.Colors
                             on car.ColorId equals color.Id
                             join
                             brand in carRentalDbContext.Brands
                             on car.BrandId equals brand.Id
                             select new CarDetailDto { BrandName = brand.Name, CarName = car.CarName, ColorName = color.Name, DailyPrice = car.DailyPrice };

                            return result.ToList();
            }
        }
    }
}
