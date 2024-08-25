using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>>  GetAll();
        IDataResult<Car> GetById(int CarId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult DeleteById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
