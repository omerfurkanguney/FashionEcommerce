using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin, EcommerceContext>, IAdminDal
    {
        public List<AdminOperationClaim> GetClaims(Admin admin)
        {
            using (var context = new EcommerceContext())
            {
                var result = from adminOperationClaim in context.AdminOperationClaims
                             join adminClaim in context.AdminClaims
                                 on adminOperationClaim.ClaimId equals adminClaim.AdminClaimId
                             where adminClaim.AdminId == admin.AdminId
                             select new AdminOperationClaim { ClaimId = adminOperationClaim.ClaimId, ClaimName = adminOperationClaim.ClaimName };
                return result.ToList();

            }
        }

        public int GetCount()
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                return context.Admins.Count();
            }
        }
    }
}
