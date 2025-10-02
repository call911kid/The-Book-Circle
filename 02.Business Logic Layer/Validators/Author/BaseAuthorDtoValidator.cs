using FluentValidation;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.BaseDtos;
using The_Book_Circle._02.Business_Logic_Layer.Helpers;

namespace The_Book_Circle._02.Business_Logic_Layer.Validators
{
    public class BaseAuthorDtoValidator<T>: AbstractValidator<T> where T : BaseAuthorDto
    {
        public BaseAuthorDtoValidator()
        {
            RuleFor(a => a.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(50).WithMessage("Full name cannot exceed 50 characters.");
            RuleFor(a => a.Biography)
                .NotEmpty().WithMessage("Biography is required.");
            RuleFor(a => a.PhotoUrl)
                .MaximumLength(500).WithMessage("Photo URL cannot exceed 500 characters.")
                .When(a => !a.PhotoUrl.IsNullOrEmpty());
        }

    }
}
