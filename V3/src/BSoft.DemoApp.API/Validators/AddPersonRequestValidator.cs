// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Runtime.CompilerServices;
using BSoft.BApp.Core.Validator.Interfaces;
using BSoft.DemoApp.API.Application.Requests;
using FluentValidation;

namespace BSoft.DemoApp.API.Validators
{
    public class AddPersonRequestValidator : AbstractValidator<AddPersonRequest>
    {
        public AddPersonRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Surname).NotNull().NotEmpty();
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty();
            RuleFor(x => x.BirthDate).Must(bd => bd < DateTime.Today.AddDays(1));
        }
    }
}
