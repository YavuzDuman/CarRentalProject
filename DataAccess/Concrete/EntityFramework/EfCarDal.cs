﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDatabaseContext>, ICarDal
    {
		public List<CarDetailDto> GetCarDetails()
		{
			using (CarDatabaseContext context = new CarDatabaseContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 join co in context.Colors
							 on c.ColorId equals co.ColorId
							 select new CarDetailDto
							 {
								 CarId = c.CarId,
								 CarName = c.CarName,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 ModelYear = c.ModelYear,
								 DailyPrice = c.DailyPrice,
								 Description = c.Description
							 };
				return result.ToList();
			}
		}

	}
}
