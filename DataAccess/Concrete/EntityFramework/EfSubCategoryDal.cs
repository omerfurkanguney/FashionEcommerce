using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSubCategoryDal : EfEntityRepositoryBase<SubCategory, EcommerceContext>, ISubCategoryDal
    {
        public List<SubCategoryDetailDto> GetSubCategoryDetails()
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                var result = from sc in context.SubCategories
                             join c in context.Categories
                             on sc.CategoryId equals c.CategoryId
                             select new SubCategoryDetailDto
                             {
                                 SubCategoryId = sc.CategoryId,
                                 CategoryName = c.CategoryName,
                                 SubCategoryName = sc.SubCategoryName,
                             };
                return result .ToList();
            }
        }
    }
}
