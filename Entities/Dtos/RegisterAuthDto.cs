using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RegisterAuthDto
    {
        public string UserName { get; set; }

        public string EmailAdress { get; set; }

        public IFormFile Image { get; set; }

        public string Password { get; set; }
    }
}
