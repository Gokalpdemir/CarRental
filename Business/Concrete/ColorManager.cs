using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        IMapper _mapper;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public ColorManager(IColorDal colorDal,IMapper mapper)
        {
            _colorDal = colorDal;
            _mapper = mapper;
        }

        public IResult Add(ColorDto colorDto)
        {
            _colorDal.Add(_mapper.Map<Color>(colorDto));
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ColorDto colorDto)
        {
           _colorDal.Delete(_mapper.Map<Color>(colorDto));
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<ColorDto>> GetAll()
        {
           return new SuccessDataResult<List<ColorDto>>(_mapper.Map<List<ColorDto>>(_colorDal.GetAll()),Messages.Listed);
        }

        public IDataResult<ColorDto> GetById(int id)
        {
            return new SuccessDataResult<ColorDto>(_mapper.Map<ColorDto>(_colorDal.Get(p => p.Id == id)),Messages.Listed);
        }

        public IResult Update(ColorDto colorDto)
        {
            _colorDal.Update(_mapper.Map<Color>(colorDto));
            return new SuccessResult(Messages.Updated);
        }
    }
}
