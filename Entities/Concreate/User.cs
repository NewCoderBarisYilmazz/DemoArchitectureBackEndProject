using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public  class User: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string EmailAdress { get; set; }

        public byte [] PasswordHash { get; set; }

        public byte []  PasswordSalt { get; set; }

    }
}
