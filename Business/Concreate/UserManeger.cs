using Business.Abstract;
using Core.Aspect.Transaction;
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
        [TransactionAspect]
        public void Add(RegisterAuthDto authDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(authDto.Password, out passwordHash,out passwordSalt);
            User user = new User();
            user.Id = 0;
            user.EmailAdress = authDto.EmailAdress;
            user.Name = authDto.UserName;
            user.ImageUrl = authDto.ImageUrl;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

          _userDal.Add(user);
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
    }
}
