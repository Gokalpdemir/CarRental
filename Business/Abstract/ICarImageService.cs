using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImageDto carImageDto);
        IResult Delete(CarImageDto carImageDto);
        IResult Update(IFormFile file, CarImageDto carImageDto);
        IDataResult<List<CarImageDto>> GetAll();
        IDataResult<List<CarImageDto>> GetByCarId(int carId);
        IDataResult<CarImageDto> GetByImageId(int imageId);
    }
}
