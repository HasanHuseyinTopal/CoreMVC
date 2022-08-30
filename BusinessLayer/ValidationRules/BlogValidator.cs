using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTittle).NotEmpty().WithMessage("Blog Başlığını Boş Bırakamazsınız");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Bırakamazsınız");
            RuleFor(x => x.BlogContent).MinimumLength(10).WithMessage("İçerik 10 Karakterden Fazla Olmalı");
            RuleFor(x => x.BlogContent).MaximumLength(150).WithMessage("İçerik 150 Karakterden Fazla Olamaz");
        }
    }
}
