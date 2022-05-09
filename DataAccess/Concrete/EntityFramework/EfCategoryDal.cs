using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,EcommerceContext>,ICategoryDal
    {
        public int GetCount()
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                return context.Categories.Count();
                //var result = (from c in context.Categories                           
                //             select c).Count();
                //return result.CompareTo(0);
                        
                
            }
        }
    }
}
