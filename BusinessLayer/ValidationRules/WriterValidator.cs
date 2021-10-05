using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını boş geçemezsiniz");  //bir kural oluşturuyoruz
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
            RuleFor(x => x.WriterAbout).Must(x => x.ToLower().Contains("a")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");
            RuleFor(x => x.WriterTitle).NotEmpty();
        }
    }
}
