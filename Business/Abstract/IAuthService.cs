using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Admin> Register(AdminForRegisterDto adminForRegisterDto, string password);
        IDataResult<Admin> Login(AdminForLoginDto adminForLoginDto);

        IResult AdminExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Admin admin);
    }
}
