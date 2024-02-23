using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaimDto>> GetAll();
        IDataResult<UserOperationClaimDto> GetById(int UserOperationClaimId);
        IResult Add(UserOperationClaimDto userOperationClaimDto);
        IResult Delete(UserOperationClaimDto userOperationClaimDto);
        IResult Update(UserOperationClaimDto userOperationClaimDto);


    }
}
