using Business.Utilities;
using Core.Business;
using Core.Result.Abstract;
using Core.Result.Concrete;
using Core.Utilities.Hashing;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Repositories.UserRepository
{
    public class UserManeger : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IFileService _fileService;
        public UserManeger(IUserDal userDal, IFileService fileService)
        {
            _userDal = userDal;
            _fileService = fileService;
        }

        public IResult Add(RegisterAuthDto authDto)
        {
            var result = BusinessRules.IsValidBusiness(CheckIfFileExtensionsIsAllow(authDto.Image));
            if (!result.Success)
                return new ErrorResult(result.Message);
            //var fileName=   _fileService.FileSaveToServer(authDto.Image, "./Content/img/");
            var fileName = "";
            _fileService.FileSaveToDataBase(authDto.Image);
            var user = CreateUser(authDto, fileName);

            _userDal.Add(user);
            return new SuccesResult();
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetByEmail(string email)
        {
            var result = _userDal.Get(p => p.EmailAdress == email);
            return result;
        }
        private User CreateUser(RegisterAuthDto authDto, string fileName)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(authDto.Password, out passwordHash, out passwordSalt);
            User user = new User();
            user.Id = 0;
            user.ImageUrl = fileName;
            user.EmailAdress = authDto.EmailAdress;
            user.Name = authDto.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
        }
        private IResult CheckIfFileExtensionsIsAllow(IFormFile file)
        {
            string fileName = file.FileName;
            var ext = fileName.Substring(fileName.LastIndexOf('.'));
            var extensions = ext.ToLower();
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
