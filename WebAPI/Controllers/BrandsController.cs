using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_brandService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result= _brandService.GetById(id);
            if(result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        

        [HttpPost("add")]
        public IActionResult Add(BrandDto brandDto)
        {
            var result = _brandService.Add(brandDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(BrandDto brandDto)
        {
            var result=_brandService.Update(brandDto);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BrandDto brandDto)
        {
            var result=_brandService.Delete(brandDto);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
