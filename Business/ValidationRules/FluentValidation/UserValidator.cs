using Entities.Concreate;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<RegisterAuthDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olmamalıdır");

            RuleFor(p => p.EmailAdress).NotEmpty().WithMessage("Email Adresi Boş Olmamalıdır");
            RuleFor(p => p.EmailAdress).EmailAddress().WithMessage("Geçerli Bir Email Giriniz");


            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("Kullanıcı Resmi Boş Olmamalıdır");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre Boş Olmamalıdır");

            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre Minumum 6 Karekter Olmalıdır");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 büyük harf olamalıdır");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 küçük harf olamalıdır");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayi içermelidir");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karekter olmalıdır");








        }
    }
}
