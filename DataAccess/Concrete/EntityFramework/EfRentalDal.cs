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

		public List<RentalDetailsDto> GetRentalDetail()
		{
			using (CarDatabaseContext context = new CarDatabaseContext())
			{
				var result = from rental in context.Rentals
							 join car in context.Cars
							 on rental.CarId equals car.CarId
							 join customer in context.Customers
							 on rental.CustomerId equals customer.CustomerId
							 join brand in context.Brands
							 on car.BrandId equals brand.BrandId
							 join user in context.Users
							 on customer.CustomerId equals user.Id
							 select new RentalDetailsDto
							 {
								 CarBrand = brand.BrandName,
								 CarDescription = car.Description,
								 CustomerName = user.FirstName,
								 RentalId = rental.RentalId
							 };
				return result.ToList();
			}
		}
	}
}
