using AutoMapper;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
       IUserOperationClaimService _userOperationClaimService;
        IMapper _mapper;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService, IMapper mapper)
        {
            _userOperationClaimService = userOperationClaimService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result = _userOperationClaimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int Id)
        {
            var result = _userOperationClaimService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaimDto userOperationClaimDto)
        {
           var result = _userOperationClaimService.Add(userOperationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserOperationClaimDto userOperationClaimDto)
        {
            var result = _userOperationClaimService.Update(userOperationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(UserOperationClaimDto userOperationClaimDto)
        {
            var result = _userOperationClaimService.Delete(userOperationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
