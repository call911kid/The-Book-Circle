using FluentValidation;
using The_Book_Circle._02.Business_Logic_Layer.DTOs;

namespace The_Book_Circle._02.Business_Logic_Layer.Validators.User
{
    public class LogoutDtoValidator: AbstractValidator<LogoutDto>
    {
        public LogoutDtoValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("Refresh token is required.");
        }
    }
}
