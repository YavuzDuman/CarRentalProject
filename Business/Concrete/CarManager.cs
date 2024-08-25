using Business.Abstract;
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

namespace Business.Concrete
{
	public class CarManager : ICarService
	{

		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{

			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}



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

		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
		}
	}
}


