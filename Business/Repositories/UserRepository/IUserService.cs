using Core.Result.Abstract;
using Entities.Concreate;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserRepository
{
    public interface IUserService
    {
        IResult Add(RegisterAuthDto authDto);
        List<User> GetAll();
        User GetByEmail(string email);

    }
}
