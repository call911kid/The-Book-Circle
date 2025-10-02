using FluentValidation;
using The_Book_Circle._02.Business_Logic_Layer.DTOs;

namespace The_Book_Circle._02.Business_Logic_Layer.Validators
{
    public class BaseBookDtoValidator<T>: AbstractValidator<T> where T : BaseBookDto
    {
        public BaseBookDtoValidator()
        { 
            RuleFor(b=>b.ISBN)
                .Matches(@"^\d{13}$").WithMessage("ISBN must be exactly 13 digits.");

            RuleFor(b=>b.Title)
                .NotEmpty().MaximumLength(200);

            RuleFor(b=>b.Subtitle)
                .MaximumLength(200);

            RuleFor(b=>b.Description)
                .NotEmpty().MaximumLength(200);

            RuleFor(b=>b.Pages)
                .InclusiveBetween(1,10000);

            RuleFor(b=>b.Language)
                .NotEmpty().MaximumLength(50);

            RuleFor(b=>b.CoverImageUrl)
                .MaximumLength(200);

            RuleFor(b=>b.PublicationDate)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Publication date cannot be in the future.");



        }
    }
}
