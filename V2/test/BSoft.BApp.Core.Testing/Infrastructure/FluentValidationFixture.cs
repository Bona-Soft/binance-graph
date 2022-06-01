// Copyright (c) Zenfolio, Inc. All rights reserved.

using Zenfolio.Common.API.Validation;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    public class FluentValidationFixture
    {
        static FluentValidationFixture() => ValidationUtils.SetupValidatorOptions();
    }
}
