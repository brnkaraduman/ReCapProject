﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [SecuredOperation("carimagemanager.add,user")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImagesExceed(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfDataExists());
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [CacheAspect]
        //[PerformanceAspect(30)]
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageExists(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(new List<CarImage> {
                    new CarImage {Id=404, CarId = carId, Date = DateTime.Now, ImagePath = Paths.DefaultCarImage}}, result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(image => image.CarId == carId), Messages.CarImagesListed);
        }

        private IResult CheckIfCarImagesExceed(int carId)
        {
            var result = _carImageDal.GetAll(image => image.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ErrorAddCarImage);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(image => image.CarId == carId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.ErrorNoCarImage);
            }
            return new SuccessResult();
        }

        private IResult CheckIfDataExists()
        {
            var result = _carImageDal.GetAll().Any();
            if (!result)
            {
                return new ErrorResult(Messages.ErrorNoSuchData);
            }
            return new SuccessResult();
        }
    }
}