using FluentValidation;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.BaseDtos;

namespace The_Book_Circle._02.Business_Logic_Layer.Validators.Publisher
{
    public class BasePublisherDtoValidator<T>: AbstractValidator<T> where T : BasePublisherDto
    {
        public BasePublisherDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Publisher name is required.")
                .MaximumLength(50).WithMessage("Publisher name must not exceed 50 characters.");
            
        }
    }
}
