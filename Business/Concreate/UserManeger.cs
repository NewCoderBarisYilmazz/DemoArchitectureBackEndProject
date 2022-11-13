using Business.Abstract;
using Core.Aspect.Transaction;
using Core.Business;
using Core.Result.Abstract;
using Core.Result.Concrete;
using Core.Utilities.Hashing;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class UserManeger:IUserService
    {
        private readonly IUserDal _userDal;

        public UserManeger(IUserDal userDal)
        {
            _userDal = userDal;
        }
       
        public IResult Add(RegisterAuthDto authDto)
        {
            string fileName = authDto.Image.FileName;
            var ext = fileName.Substring(fileName.LastIndexOf('.'));
            var extensions = ext.ToLower();
            var result=BusinessRules.IsValidBusiness(CheckIfFileExtensionsIsAllow(extensions));
            if (!result.Success)
                return new ErrorResult(result.Message);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(authDto.Password, out passwordHash,out passwordSalt);
            User user = new User();
            user.Id = 0;
            user.EmailAdress = authDto.EmailAdress;
            user.Name = authDto.UserName;
            user.ImageUrl = "";
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
          _userDal.Add(user);
            return new SuccesResult();
        }

        public List<User> GetAll()
        {
          return  _userDal.GetAll();
        }

        public User GetByEmail(string email)
        {
            var result = _userDal.Get(p => p.EmailAdress == email);
            return result;
        }
        private IResult CheckIfFileExtensionsIsAllow(string extensions)
        {
            List<string> extensionsList = new List<string>()
            {
                ".png",".jpg",".jpeg",".gif"
            };
            if (!extensionsList.Contains(extensions))
                return new ErrorResult("Lütfen .png,.jpg,.jpeg,.gif uzantılı bir veri seçiniz");
            return new SuccesResult();

        }
    }
}
