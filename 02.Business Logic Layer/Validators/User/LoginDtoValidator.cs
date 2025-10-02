using FluentValidation;
using The_Book_Circle._02.Business_Logic_Layer.DTOs;

namespace The_Book_Circle._02.Business_Logic_Layer.Validators.User
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
            
        }
    }
}
