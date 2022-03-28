using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISizeService
    {
        IDataResult<List<Size>>GetAll();
        IDataResult<Size> GetById(int sizeId);
        IResult Add(Size size);
        IResult Update(Size size);
        IResult Delete(int sizeId);

    }
}
