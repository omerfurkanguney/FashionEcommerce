using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserAuthManager : IUserAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public UserAuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper; 
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            //var claims = _adminService.GetClaims(admin);
            var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }
           
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.customer.PasswordHash, userToCheck.customer.PasswordSalt))
            {
                return new ErrorDataResult<User>("Parola hatası");
            }

            
            return new SuccessDataResult<User>(userToCheck, "Başarılı giriş");
        }

        public IDataResult<Customer> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var customer = new Customer
            {              
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RegisterDate = userForRegisterDto.RegisterDate,
                Phone = userForRegisterDto.Phone,
                //Status = true
            };
            _userService.Add(customer);
            
            return new SuccessDataResult<Customer>(customer, "Kayıt oldu");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(AuthorizationMessages.AdminAvailable);
            }
            return new SuccessResult();
        }
    }
}
