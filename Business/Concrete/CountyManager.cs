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
    public class CountyManager : ICountyService
    {
        ICountyDal _countyDal;
        public CountyManager(ICountyDal countyDal)
        {
            _countyDal = countyDal;
        }
        public IResult Add(County county)
        {
            _countyDal.Add(county);
            return new SuccessResult(CountyMessages.CountyAdded);
        }

        public IResult Delete(County county)
        {
            _countyDal.Delete(county);
            return new SuccessResult(CountyMessages.CountyDeleted);
        }

        public IDataResult<List<County>> GetAll()
        {
            return new SuccessDataResult<List<County>>(_countyDal.GetAll(),CountyMessages.CountyListed);
        }

        public IDataResult<County> GetById(int countyId)
        {
            return new SuccessDataResult<County>(_countyDal.Get(c=>c.CountyId == countyId), CountyMessages.CountyListed);

        }

        public IDataResult<List<CountyDetailDto>> GetCountyDetails()
        {
            return new SuccessDataResult<List<CountyDetailDto>>(_countyDal.GetCountyDetails());
        }

        public IResult Update(County county)
        {
            _countyDal.Update(county);
            return new SuccessResult(CountyMessages.CountyUpdated);
        }
    }
}
