using BookStore.Data;
using FluentValidation;

namespace BookStore.Models.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.FirstNameOfAuthor).Must(name => !string.IsNullOrEmpty(name) && char.IsUpper(name[0]))
             .WithMessage("Imię musi zaczynać się od dużej litery.");
            RuleFor(x => x.LastNameOfAuthor).Must(name => !string.IsNullOrEmpty(name) && char.IsUpper(name[0]))
            .WithMessage("Nazwisko musi zaczynać się od dużej litery.");
            RuleFor(x => x.Rating).InclusiveBetween(1, 10).WithMessage("Ocena musi być wartością od 1 do 10.");
        }
    }
}
