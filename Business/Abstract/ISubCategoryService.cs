using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubCategoryService
    {
        IDataResult<List<SubCategory>>GetAll();
        IDataResult<SubCategory> GetById(int subCategoryId);
        IResult Add(SubCategory subCategory);
        IResult Update(SubCategory subCategory);
        IResult Delete(SubCategory SubCategory);
    }
}
