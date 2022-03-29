using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminOperationClaimService
    {
        IDataResult<List<AdminOperationClaim>> GetAll();
        IDataResult<AdminOperationClaim> GetById(int claimId);
        IResult Add(AdminOperationClaim adminOperationClaim);
        IResult Delete(AdminOperationClaim adminOperationClaim);
        IResult Update(AdminOperationClaim adminOperationClaim);

        IResult Add1(AdminOperationClaim adminOperationClaim); 
    }
}
