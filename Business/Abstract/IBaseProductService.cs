using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseProductService
    {
        IDataResult<List<BaseProduct>> GetAll();
        IDataResult<BaseProduct> GetById(int baseProductId);
        IResult Add(BaseProduct baseProduct);
        IResult Update(BaseProduct baseProduct);
        IResult Delete(BaseProduct baseProduct);
    }
}
