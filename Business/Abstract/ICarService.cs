using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(int id);
        List<CarDetailDto> GetCarDetails();

    }
}
