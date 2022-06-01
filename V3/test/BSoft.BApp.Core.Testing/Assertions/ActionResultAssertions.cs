// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using EnsureThat;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Zenfolio.Common.API.Mvc;
using Zenfolio.Common.Testing.Infrastructure;

namespace Zenfolio.Common.Testing.Assertions
{
    public class ActionResultAssertions : ReferenceTypeAssertions<ActionResult, ActionResultAssertions>
    {
        public ActionResultAssertions(ActionResult actionResult)
            => Subject = actionResult;

        protected override string Identifier => nameof(ActionResultAssertions);

        public void HaveStatusCode(int expectedStatusCode)
            => HaveStatusCode(expectedStatusCode, string.Empty);

        public void HaveStatusCode(int expectedStatusCode, string because, params object[] becauseArgs)
        {
            int? actualStatusCode = (Subject as IStatusCodeActionResult)?.StatusCode;

            Execute.Assertion
                .ForCondition(actualStatusCode == expectedStatusCode)
                .BecauseOf(because, becauseArgs)
                .FailWith(Constants.FailWithStatusCodeMessage, expectedStatusCode, actualStatusCode);
        }

        public void HaveRedirectUrl(string expectedUrl)
            => HaveRedirectUrl(expectedUrl, string.Empty);

        public void HaveRedirectUrl(string expectedUrl, string because, params object[] becauseArgs)
        {
            Ensure.String.IsNotNullOrWhiteSpace(expectedUrl, nameof(expectedUrl));

            string actualUrl = (Subject as RedirectResult)?.Url;

            Execute.Assertion
                .ForCondition(string.Equals(actualUrl, expectedUrl, StringComparison.Ordinal))
                .BecauseOf(because, becauseArgs)
                .FailWith(Constants.FailWithRedirectUrlMessage, expectedUrl, actualUrl);
        }

        public void HaveException(int expectedStatusCode, Exception expectedException)
            => HaveException(expectedStatusCode, expectedException, string.Empty);

        public void HaveException(
            int expectedStatusCode,
            Exception expectedException,
            string because,
            params object[] becauseArgs)
        {
            Ensure.Any.IsNotNull(expectedException, nameof(expectedException));

            var actualProblemDetails = (Subject as ObjectResult)?.Value as ProblemDetails;
            var expectedProblemDetails = expectedException.ToProblemDetails(false, expectedStatusCode);

            actualProblemDetails.Should().BeEquivalentTo(
                expectedProblemDetails,
                config => config
                    .Excluding(pd => pd.Instance)
                    .Excluding(pd => pd.Extensions),
                because,
                becauseArgs);
        }
    }
}
