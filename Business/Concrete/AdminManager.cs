using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public Admin GetByMail(string email)
        {
            return _adminDal.Get(a => a.Email == email);
        }

        public List<AdminOperationClaim> GetClaims(Admin admin)
        {
            return _adminDal.GetClaims(admin);
        }
    }
}
