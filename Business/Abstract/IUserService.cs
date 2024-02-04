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
    public interface IUserService
    {
        public IResult Add(UserDto userDto);
        public IResult Delete(UserDto userDto);

        public IResult Update(UserDto userDto);
        public IDataResult<UserDto> GetById(int id);
        public IDataResult<List<UserDto>> GetAll();
    }
}
