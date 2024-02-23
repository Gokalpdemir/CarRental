using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
           var result =  _operationClaimService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result=_operationClaimService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
       public IActionResult Add(OperationClaimDto operationClaimDto)
        {
            var result=_operationClaimService.Add(operationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(OperationClaimDto operationClaimDto)
        {
            var result =_operationClaimService.Delete(operationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(OperationClaimDto operationClaimDto)
        {
            var result =_operationClaimService.Update(operationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
    }
}
