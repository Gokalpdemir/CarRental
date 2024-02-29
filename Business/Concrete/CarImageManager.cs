using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        IMapper _mapper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper, IMapper mapper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
            _mapper = mapper;

        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImageDto carImageDto)
        {
            var result = BusinessRules.Run(checkCarImagesLimit(carImageDto.CarId));
            if (result != null)
            {
                return result;
            }
            carImageDto.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            _carImageDal.Add(_mapper.Map<CarImage>(carImageDto));
            return new SuccessResult(Messages.Added);
        }
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImageDto carImageDto)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImageDto.ImagePath);
            _carImageDal.Delete(_mapper.Map<CarImage>(carImageDto));
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<CarImageDto>> GetAll()
        {

            return new SuccessDataResult<List<CarImageDto>>(_mapper.Map<List<CarImageDto>>(_carImageDal.GetAll()), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<List<CarImageDto>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(checkCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImageDto>>(GetDefaultImage(carId).Data, result.Message);
            }
            return new SuccessDataResult<List<CarImageDto>>(_mapper.Map<List<CarImageDto>>(_carImageDal.GetAll(c => c.CarId == carId)), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<CarImageDto> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImageDto>(_mapper.Map<CarImageDto>(_carImageDal.Get(c => c.Id == imageId)), Messages.Listed);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImageDto carImageDto)
        {
            carImageDto.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImageDto.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(_mapper.Map<CarImage>(carImageDto));
            return new SuccessResult();
        }

        [CacheAspect]
        private IDataResult<List<CarImageDto>> GetDefaultImage(int carId)
        {
            List<CarImageDto> carImageDtos = new List<CarImageDto>();
            carImageDtos.Add(new CarImageDto { CarId = carId, ImagePath = "DefaultImage.jpg", CreatedDate = DateTime.Now });
            return new SuccessDataResult<List<CarImageDto>>(carImageDtos);
        }

        private IResult checkCarImagesLimit(int carID)
        {
            int carImagesCount = _carImageDal.GetAll(c => c.CarId == carID).Count;
            if (carImagesCount >= 5)
            {
                return new ErrorResult(Messages.ImagesLimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult checkCarImage(int carId)
        {
            bool carImages = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (carImages)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.DefaultImage);
        }
    }
}

