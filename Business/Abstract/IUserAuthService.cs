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
    public interface IUserAuthService
    {
        IDataResult<Customer> Register(UserForRegisterDto userForRegisterDto, string password); //Bu User olsa ?
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
