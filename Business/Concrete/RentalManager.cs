using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental rental)
        {
            if (_rentalDal.CheckRental(rental))
            {
				return new ErrorResult("araba teslim edilmemiş");
			}
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(int id)
        {
            var deletedRental = _rentalDal.Get(r => r.RentalId == id);
            _rentalDal.Delete(deletedRental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
		}

		public IDataResult<Rental> GetById(int CarId)
		{
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.CarId == CarId));
		}

		public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

		public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
		{
			return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails());
		}
	}
}
