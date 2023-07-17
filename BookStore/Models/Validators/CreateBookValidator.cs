using BookStore.Data;
using FluentValidation;

namespace BookStore.Models.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.FirstNameOfAuthor).Must(name => !string.IsNullOrEmpty(name) && char.IsUpper(name[0]))
             .WithMessage("The name must start with a capital letter.");
            RuleFor(x => x.LastNameOfAuthor).Must(name => !string.IsNullOrEmpty(name) && char.IsUpper(name[0]))
            .WithMessage("The surname must start with a capital letter.");
            RuleFor(x => x.Rating).InclusiveBetween(1, 10).WithMessage("The rating must be a value between 1 and 10.");
        }
    }
}
