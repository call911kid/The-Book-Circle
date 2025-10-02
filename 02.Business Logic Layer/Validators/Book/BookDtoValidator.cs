using FluentValidation;
using The_Book_Circle.DTOs;

namespace The_Book_Circle._02.Business_Logic_Layer.Validators
{
    public class BookDtoValidator:BaseBookDtoValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.AuthorID).GreaterThan(0).WithMessage("AuthorID must be greater than 0");
            RuleFor(x => x.PublisherID).GreaterThan(0).WithMessage("PublisherID must be greater than 0");
            RuleFor(x => x.GenresIDs).NotEmpty().WithMessage("GenresIDs must not be empty");
            RuleFor(x => x.GenresIDs).MustBeUniqueItems().WithMessage("GenresIDs must not contain duplicates");
            RuleForEach(x => x.GenresIDs).GreaterThan(0).WithMessage("Each GenreID must be greater than 0");
        }

    }
}
