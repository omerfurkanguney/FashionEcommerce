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
    public class StatusManager : IStatusService
    {
        IStatusDal _statusDal;
        public StatusManager(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }
        public IResult Add(Status status)
        {
           _statusDal.Add(status);
            return new SuccessResult(StatusMessages.StatusAdded);
        }

        public IResult Delete(Status status)
        {
            _statusDal.Delete(status);
            return new SuccessResult(StatusMessages.StatusDeleted);
        }

        public IDataResult<List<Status>> GetAll()
        {
            return new SuccessDataResult<List<Status>>(_statusDal.GetAll(),StatusMessages.StatusListed);
        }

        public IDataResult<Status> GetById(int statusId)
        {
            return new SuccessDataResult<Status>(_statusDal.Get(s => s.StatusId == statusId), StatusMessages.StatusListed);
        }

        public IResult Update(Status status)
        {
            _statusDal.Update(status);
            return new SuccessResult(StatusMessages.StatusAdded);
        }
    }
}
