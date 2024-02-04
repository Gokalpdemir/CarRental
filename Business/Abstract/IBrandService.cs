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
    public interface IBrandService
    {
        IDataResult<List<BrandDto>> GetAll();
        IResult Add(BrandDto brandDto);
        IResult Update(BrandDto brandDto);
        IResult Delete(BrandDto brandDto);
        IDataResult<BrandDto> GetById(int id);
    }
}
