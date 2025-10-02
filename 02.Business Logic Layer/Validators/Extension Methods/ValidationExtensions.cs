using FluentValidation;

namespace The_Book_Circle._02.Business_Logic_Layer.Validators
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, ICollection<TElement>> MustBeUniqueItems<T, TElement>(this IRuleBuilder<T, ICollection<TElement>> ruleBuilder)
        {
            return ruleBuilder
                .Must(list => list.Distinct().Count() == list.Count);
        }

        public static IRuleBuilderOptions<T, IEnumerable<TElement>> MustBeUniqueItems<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        {
            return ruleBuilder
                .Must(list => list.Distinct().Count() == list.Count());
        }
        public static IRuleBuilderOptions<T,string> MustBeValidName<T>(this IRuleBuilder<T,string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
        }
        public static IRuleBuilderOptions<T,string> MustBeSecurePassword<T>(this IRuleBuilder<T,string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Password is required.")
                .Length(8, 100).WithMessage("Password must be between 8 and 100 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        }
    }
}
