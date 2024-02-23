using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMappers
{
    public class OperationClaimMapper:Profile
    {
        public OperationClaimMapper()
        {
            CreateMap<OperationClaimDto,OperationClaim>().ReverseMap();
        }
    }
}
