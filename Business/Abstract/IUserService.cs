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
        IResult Add(UserDto userDto);
        IResult Delete(UserDto userDto);

        IDataResult<List<OperationClaim>> GetClaims(UserDto userDto);

        IDataResult<UserDto> GetByMail(string email);
        IResult Update(UserDto userDto);
        IDataResult<UserDto> GetById(int id);
        IDataResult<List<UserDto>> GetAll();
    }
}
