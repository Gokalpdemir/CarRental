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
    public interface ICustomerService
    {
        public IResult Add(CustomerDto customerDto);
        public IResult Update(CustomerDto customerDto);
        public IResult Delete(CustomerDto customerDto);
        public IDataResult<CustomerDto> GetById(int id);
        public IDataResult<List<CustomerDto>> GetAll();

    }
}
