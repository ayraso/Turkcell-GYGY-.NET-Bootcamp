using FluentValidation;
using TVRS.WebUI.Models;

namespace TVRS.WebUI.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUser>
    {
        public LoginUserValidator()
        {
            RuleFor(model => model.Tin)
                .NotEmpty().WithMessage("TC Kimlik Numarası boş geçilemez.");
            RuleFor(model => model.Password)
                .NotEmpty().WithMessage("Şifre boş geçilemez.");
        }
    }
}
