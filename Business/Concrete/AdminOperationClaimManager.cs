using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminOperationClaimManager : IAdminOperationClaimService
    {
        IAdminOperationClaimDal _claimDal;
        public AdminOperationClaimManager(IAdminOperationClaimDal claimDal)
        {
            _claimDal = claimDal;
        }
        public IResult Add(AdminOperationClaim adminOpetationClaim)
        {
            _claimDal.Add(adminOpetationClaim);
            return new SuccessResult(ClaimMessages.ClaimAdded);
        }

        public IResult Delete(AdminOperationClaim adminOpetationClaim)
        {
            _claimDal.Delete(adminOpetationClaim);
            return new SuccessResult(ClaimMessages.ClaimDeleted);
        }

        public IDataResult<List<AdminOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<AdminOperationClaim>>(_claimDal.GetAll(),ClaimMessages.ClaimListed);
        }

        public IDataResult<AdminOperationClaim> GetById(int claimId)
        {
            return new SuccessDataResult<AdminOperationClaim>(_claimDal.Get(c=>c.ClaimId==claimId), ClaimMessages.ClaimListed);
        }

        public IResult Update(AdminOperationClaim adminOperationClaim)
        {
            _claimDal.Update(adminOperationClaim);
            return new SuccessResult(ClaimMessages.ClaimUpdated);
        }
    }
}
