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
    public class GenderManager : IGenderService
    {
        IGenderDal _genderDal;

        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }
        public IResult Add(Gender gender)
        {
           _genderDal.Add(gender);
            return new SuccessResult(GenderMessages.GenderAdded);
        }

        public IResult Delete(Gender gender)
        {
            _genderDal.Delete(gender);
            return new SuccessResult(GenderMessages.GenderDeleted);
        }

        public IDataResult<List<Gender>> GetAll()
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetAll(), GenderMessages.GenderListed);
        }

        public IDataResult<Gender> GetById(int genderId)
        {
            return new SuccessDataResult<Gender>(_genderDal.Get(g => g.GenderID == genderId), GenderMessages.GenderListed);
        }

        public IResult Update(Gender gender)
        {
            _genderDal.Update(gender);
            return new SuccessResult(GenderMessages.GenderUpdated); 
        }
    }
}
