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
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }
        public IResult Add(SubCategory subCategory)
        {
            _subCategoryDal.Add(subCategory);
            return new SuccessResult(SubCategoryMessages.SubCategoryAdded);
        }

        public IResult Delete(SubCategory subCategory)
        {
            _subCategoryDal.Delete(subCategory);
            return new SuccessResult(SubCategoryMessages.SubCategoryDeleted);
        }

        public IDataResult<List<SubCategory>> GetAll()
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetAll(),SubCategoryMessages.SubCategoryListed );
        }

        public IDataResult<SubCategory> GetById(int subCategoryId)
        {
            return new SuccessDataResult<SubCategory>(_subCategoryDal.Get(sc => sc.SubCategoryId == subCategoryId), SubCategoryMessages.SubCategoryListed);
        }

        public IResult Update(SubCategory subCategory)
        {
            _subCategoryDal.Update(subCategory);
            return new SuccessResult(SubCategoryMessages.SubCategoryUpdated);
        }
    }
}
