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
    public class EfCountyDal:EfEntityRepositoryBase<County,EcommerceContext>,ICountyDal
    {
        public List<CountyDetailDto> GetCountyDetails()
        {
            using(EcommerceContext context = new EcommerceContext())
            {
                var result = from co in context.Counties
                             join c in context.Cities
                             on co.CityId equals c.CityId
                             select new CountyDetailDto
                             {
                                 CountyId = co.CountyId,
                                 CityName = c.CityName,
                                 CountyName = co.CountyName,
                             };
                return result.ToList();
            }
        }
    }
}
