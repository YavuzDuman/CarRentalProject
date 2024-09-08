using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarDatabaseContext>, IRentalDal
    {
		public bool CheckRental(Rental rental)
		{
			using (CarDatabaseContext context = new CarDatabaseContext())
			{
				var result = from r in context.Rentals
							 where r.CarId == rental.CarId &&
							 r.ReturnDate >= rental.RentDate
							 select r;
				return result.Any();
			}
		}

		public List<RentalDetailsDto> GetRentalDetails()
		{
			using (var context = new CarDatabaseContext())
			{
				var result = from rental in context.Rentals
							 join car in context.Cars
							 on rental.CarId equals car.CarId
							 join brand in context.Brands
							 on car.BrandId equals brand.BrandId
							 join user in context.Users
							 on rental.RentalId equals user.Id
							 select new RentalDetailsDto()
							 {
								 RentalId = rental.RentalId,
								 CarName = car.CarName,
								 BrandName = brand.BrandName,
								 CustomerName = user.FirstName + " " + user.LastName,
								 RentDate = rental.RentDate,
								 ReturnDate = rental.ReturnDate,
							 };
				return result.ToList();
			}
		}
	}
}
