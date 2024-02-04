using Core.Utilities.Results;
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
        IDataResult<List<CarDto>> GetAll();
        IResult Add(CarDto carDto);
       
        IResult Update(CarDto carDto);
        IResult Delete(CarDto carDto);
        IDataResult<CarDto> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();


    }
}
