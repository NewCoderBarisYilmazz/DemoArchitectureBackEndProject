using Business.ValidationRules.FluentValidation;
using Core.Aspect.Transaction;
using Core.Aspect.Validation;
using Core.Business;
using Core.Result.Abstract;
using Core.Result.Concrete;
using Core.Utilities.Hashing;
using Core.ValidationTools;
using Core.Utilities.MathematicalOperationsExtensions;
using Entities.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.UserRepository;

namespace Business.Repositories.AuthRepository
{
    public class AuthManeger : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManeger(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(LoginAuthDto loginAuthDto)
        {
            var user = _userService.GetByEmail(loginAuthDto.Email);
            var result = HashingHelper.VerifyPasswordHash(loginAuthDto.Password, user.PasswordHash, user.PasswordSalt);
            if (result)
                return "Kayıt Başarılı";
            return "Kayıt Başarısız";



        }
        [ValidationAspect(typeof(UserValidator))]

        public IResult Register(RegisterAuthDto registerDto)
        {

            //ValidationResult result = userValidator.Validate(authDto);

            var busisnessValidationResult = BusinessRules.IsValidBusiness(CheckEmailExist(registerDto.EmailAdress), CheckIfImageSizeIsLessThanOneMb(registerDto.Image.Length));
            if (busisnessValidationResult.Success)
            {
                var result = _userService.Add(registerDto);
                if (!result.Success)
                    return new ErrorResult(result.Message);
                return new SuccesResult("Kayıt Başarılı");
            }
            return new ErrorResult(busisnessValidationResult.Message);


        }
        private IResult CheckEmailExist(string email)
        {
            var list = _userService.GetByEmail(email);
            if (list != null)
                return new ErrorResult("Bu Email zaten kayıtlı");
            return new SuccesResult();
        }
        private IResult CheckIfImageSizeIsLessThanOneMb(long imgsize)
        {
            if (imgsize.ConvertLongToMbMethod() > 1)
                return new ErrorResult("Dosya boyutu 1 mb büyük Olamaz");
            return new SuccesResult();
        }
    }
}
