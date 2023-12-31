﻿using BookStore.Data;
using FluentValidation;

namespace BookStore.Models.Validators
{
    public class RegisterUserValidator : AbstractValidator<UserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(c => c.Password);
        }
    }
}
