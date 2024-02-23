using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaimDto operationClaimDto);
        IResult Delete(OperationClaimDto operationClaimDto);
        IResult Update(OperationClaimDto operationClaimDto);
        IDataResult<OperationClaimDto> GetById(int claimId);
        IDataResult<List<OperationClaimDto>> GetAll();

    }
}
