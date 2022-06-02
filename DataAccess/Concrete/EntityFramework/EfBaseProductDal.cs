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
    public class EfBaseProductDal:EfEntityRepositoryBase<BaseProduct,EcommerceContext>,IBaseProductDal
    {
        public List<ProductDetailDto> GetBaseProductDetails()
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                var result = from bp in context.BaseProducts
                             join p in context.Products
                             on bp.BaseProductId equals p.BaseProductId
                             join f in context.Fits
                             on bp.FitId equals f.FitId
                             join g in context.Genders
                             on bp.GenderId equals g.GenderID                          
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                            
                       
                             select new ProductDetailDto
                             {
                                 BaseProductId = bp.BaseProductId,
                                 ProductId = p.ProductId,
                                 FitName = f.FitName,
                                 GenderName= g.GenderName,
                                 ColorName = c.ColorName,
                                 Price = p.Price,
                                 Discount = p.Discount,
                                 Date = p.Date,                             
                                 ProductCode =  bp.ProductCode,
                                 ProductName = bp.ProductName,
                                 Description = bp.Description,
                                 
                             };
                return result.ToList();
            }
        }
    }
}
