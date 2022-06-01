// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.DemoApp.API.Application.Requests;
using FluentValidation;

namespace BSoft.DemoApp.API.Validators.ProofOfConcept
{
    public class UpdatePersonRequestValidator : AbstractValidator<UpdatePersonRequest>
    {
        public UpdatePersonRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Surname).NotNull().NotEmpty();
        }
    }
}
