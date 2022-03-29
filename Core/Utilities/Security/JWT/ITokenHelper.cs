using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        AccessToken CreateAdminToken(Admin admin, List<AdminOperationClaim> adminOperationClaims);
    }
}

//23.05 Dersteyiz