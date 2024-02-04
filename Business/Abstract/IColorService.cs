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
    public interface IColorService
    {
        IDataResult<List<ColorDto>> GetAll();
        IResult Add(ColorDto color);
        IResult Update(ColorDto color);
        IResult Delete(ColorDto color);
        IDataResult<ColorDto> GetById(int id);
    }
}
