// Copyright (c) BonaSoft, Inc. All rights reserved.

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    public static class Constants
    {
        #region Infrastructure

        public const string IntegrationTestsCollection = nameof(IntegrationTestsCollection);

        #endregion

        #region Messages

        public const string FailWithStatusCodeMessage = "Expected status code to be {0}{reason}, but found {1}.";
        public const string FailWithRedirectUrlMessage = "Expected redirect URL to be {0}{reason}, but found {1}.";

        public const string NoOtherErrorsWereFoundMessage = "no other errors were found";
        public const string OtherErrorsWereFoundMessage = "other errors were found:{0}{1}";
        public const string PropertyErrorMessage = "Property: \"{0}\", Error: \"{1}\"";
        public const string ExpectedPropertyMessage = "{0}Expected property: \"{1}\"";

        #endregion
    }
}
