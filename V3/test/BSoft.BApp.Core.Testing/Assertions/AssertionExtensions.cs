// Copyright (c) Zenfolio, Inc. All rights reserved.

using FluentAssertions.Specialized;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Zenfolio.Common.Contract.Types;

namespace Zenfolio.Common.Testing.Assertions
{
    public static class AssertionExtensions
    {
        public static ActionResultAssertions Should(this ActionResult actualValue)
            => new ActionResultAssertions(actualValue);

        public static ValidationResultAssertions Should(this ValidationResult actualValue)
            => new ValidationResultAssertions(actualValue);

        public static ExceptionAssertions<ZenfolioException> ThrowZenfolioException(
            this AsyncFunctionAssertions asyncFunctionAssertions,
            ErrorType errorType,
            params object[] messageArgs)
        {
            return asyncFunctionAssertions
                .Throw<ZenfolioException>()
                .WithMessage(errorType.Default(messageArgs).Message)
                .Where(ex => ex.Title == errorType.Title && ex.Code == errorType.Code);
        }
    }
}
