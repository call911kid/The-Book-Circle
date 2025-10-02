using FluentValidation;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.BaseDtos;

namespace The_Book_Circle._02.Business_Logic_Layer.Validators.Genre
{
    public class BaseGenreDtoValidator<T>: AbstractValidator<T> where T : BaseGenreDto
    {
        public BaseGenreDtoValidator()
        {
            RuleFor(g => g.Name)
                .MustBeValidName();
            RuleFor(g => g.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        }
    }
}
