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
    public class FitManager : IFitService
    {
        IFitDal _fitDal;
        public FitManager(IFitDal fitDal)
        {
            _fitDal = fitDal;
        }
        public IResult Add(Fit fit)
        {
            _fitDal.Add(fit);
            return new SuccessResult(FitMessages.FitAdded);
        }

        public IResult Delete(int fitId)
        {
            var result = _fitDal.Get(f=>f.FitId == fitId);
            _fitDal.Delete(result);
            return new SuccessResult(FitMessages.FitDeleted);
        }

        public IDataResult<List<Fit>> GetAll()
        {
           return new SuccessDataResult<List<Fit>>(_fitDal.GetAll(),FitMessages.FitListed);
        }

        public IDataResult<Fit> GetById(int fitId)
        {
            return new SuccessDataResult<Fit>(_fitDal.Get(f => f.FitId == fitId), FitMessages.FitListed);
        }

        public IResult Update(Fit fit)
        {
            _fitDal.Update(fit);
            return new SuccessResult(FitMessages.FitUpdated);
        }
    }
}
