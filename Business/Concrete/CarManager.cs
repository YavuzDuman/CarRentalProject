﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Entities.DTOs;
using Core.Utilities;
using Core.Utilities.Results;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{

		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Add(Car car)
		{
			BusinessRules.Run(CheckIfCarNameExists(car.CarName));
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		public IResult DeleteById(int id)
		{
			var deletedCar = _carDal.Get(c => c.CarId == id);
			_carDal.Delete(deletedCar);
			return new SuccessResult(Messages.CarDeleted);
		}

		[CacheAspect]
		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), "Ürünler Listelendi");

		}

		public IDataResult<Car> GetCarsByBrandId(int brandId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == brandId));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int colorId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}
		[CacheAspect]
		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
		}

		private IResult CheckIfCarNameExists(string carName)
		{
			var result = _carDal.GetAll(c=>c.CarName == carName).Any();
			if (result)
			{
				return new ErrorResult(Messages.CarNameAlreadyExists);
			}
			return new SuccessResult();
		} 
	}
}


