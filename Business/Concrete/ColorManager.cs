using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new SuccessResult(ColorMessages.ColorAdded);
        }

        public IResult Delete(int colorId)
        {
            var result = _colorDal.Get(c => c.ColorId == colorId);
            _colorDal.Delete(result);
            return new SuccessResult(ColorMessages.ColorDeleted);
            
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), ColorMessages.ColorListed);

        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
           
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(ColorMessages.ColorUpdated);
        }
    }
}
