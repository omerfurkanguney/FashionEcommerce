using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<AdminOperationClaim>GetClaims(Admin admin);
        void Add(Admin admin);
        Admin GetByMail(string email);
        public int GetCount();
    }
}
