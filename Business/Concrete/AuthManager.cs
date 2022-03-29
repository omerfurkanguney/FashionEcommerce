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
    public class AuthManager : IAuthService
    {
        private IAdminService _adminService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IAdminService adminService,ITokenHelper tokenHelper)
        {
            _adminService = adminService;
            _tokenHelper = tokenHelper; 
        }
        public IResult AdminExists(string email)
        {
            if (_adminService.GetByMail(email) != null)
            {
                return new ErrorResult(AuthorizationMessages.AdminAvailable);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Admin admin)
        {
            var claims = _adminService.GetClaims(admin);
            var accessToken = _tokenHelper.CreateAdminToken(admin, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }

        public IDataResult<Admin> Login(AdminForLoginDto adminForLoginDto)
        {
            var adminToCheck = _adminService.GetByMail(adminForLoginDto.Email);
            if (adminToCheck == null)
            {
                return new ErrorDataResult<Admin>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(adminForLoginDto.Password, adminToCheck.PasswordHash, adminToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Admin>("Parola hatası");
            }

            return new SuccessDataResult<Admin>(adminToCheck, "Başarılı giriş");
        }

        public IDataResult<Admin> Register(AdminForRegisterDto adminForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                Email = adminForRegisterDto.Email,
                FirstName = adminForRegisterDto.FirstName,
                LastName = adminForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RegisterDate = adminForRegisterDto.RegisterDate,
                Phone = adminForRegisterDto.Phone,
                //Status = true
            };
            _adminService.Add(admin);
            return new SuccessDataResult<Admin>(admin, "Kayıt oldu");
        }
    }
}
