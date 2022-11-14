using Core.Result.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.AuthRepository
{
    public interface IAuthService
    {
        IResult Register(RegisterAuthDto registerDto);

        string Login(LoginAuthDto loginAuthDto);
    }
}
