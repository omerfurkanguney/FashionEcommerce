using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseProductManager : IBaseProductService
    {
        IBaseProductDal _baseProductDal;
        public BaseProductManager(IBaseProductDal baseProductDal)
        {
            _baseProductDal = baseProductDal;
        }
        public IResult Add(BaseProduct baseProduct)
        {
            _baseProductDal.Add(baseProduct);
            return new SuccessResult(BaseProductMessages.BaseProductAdded);
        }

        public IResult Delete(BaseProduct baseProduct)
        {
            _baseProductDal.Delete(baseProduct);
            return new SuccessResult(BaseProductMessages.BaseProductDeleted);
        }

        public IDataResult<List<BaseProduct>> GetAll()
        {
            return new SuccessDataResult<List<BaseProduct>>(_baseProductDal.GetAll(),BaseProductMessages.BaseProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetBaseProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_baseProductDal.GetBaseProductDetails());
        }

        


        public IDataResult<BaseProduct> GetById(int baseProductId)
        {
            return new SuccessDataResult<BaseProduct>(_baseProductDal.Get(bp => bp.BaseProductId == baseProductId),BaseProductMessages.BaseProductListed);
        }

        public IResult Update(BaseProduct baseProduct)
        {
            _baseProductDal.Update(baseProduct);
            return new SuccessResult(BaseProductMessages.BaseProductUpdated);
        }
    }
}
