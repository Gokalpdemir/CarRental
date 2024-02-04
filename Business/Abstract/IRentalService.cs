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
    public interface IRentalService
    {
        public IResult Add(RentalDto rentalDto);
        public IResult Delete(RentalDto rentalDto);
        public IResult Update(RentalDto rentalDto);
        public IDataResult<List<RentalDto>> GetAll();
        public IDataResult<RentalDto> GetById(int id);

    }
}
