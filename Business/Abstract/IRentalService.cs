﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService 
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(int id);
        IDataResult<List<Rental >> GetAll();
		IDataResult<Rental> GetById(int CarId);
        IDataResult<List<RentalDetailsDto>> GetRentalDetails();
	}
}
