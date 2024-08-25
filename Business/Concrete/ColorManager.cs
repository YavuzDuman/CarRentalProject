using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(int id)
        {
            var deletedColor = _colorDal.Get(c => c.ColorId == id);
            _colorDal.Delete(deletedColor);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), "Ürünler Listelendi");
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
