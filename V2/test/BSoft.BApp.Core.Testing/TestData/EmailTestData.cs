// Copyright (c) Zenfolio, Inc. All rights reserved.

using System.Collections.Generic;
using CommonConstants = Zenfolio.Common.Contract.Constants.Constants;

namespace Zenfolio.Common.Testing.TestData
{
    public static class EmailTestData
    {
        public static IEnumerable<object[]> InvalidEmails(string errorMessage)
        {
            return new object[][]
            {
                new object[] { null, new[] { CommonConstants.ErrorEmailNotSpecified } },
                new object[] { string.Empty, new[] { CommonConstants.ErrorEmailNotSpecified, errorMessage } },
                new object[] { "someemail", new[] { errorMessage } },
                new object[] { "@test.com", new[] { errorMessage } },
                new object[] { "someemail@test.", new[] { errorMessage } },
                new object[] { "john", new[] { errorMessage } },
                new object[] { "john doe", new[] { errorMessage } },
                new object[] { "@john", new[] { errorMessage } },
                new object[] { "john@gmail", new[] { errorMessage } },
                new object[] { "john <john@mail.com>", new[] { errorMessage } },
                new object[] { "Abc.example.com", new[] { errorMessage } },
                new object[] { "A@b@c@example.com", new[] { errorMessage } },
                new object[] { "john..doe@example.com", new[] { errorMessage } },
                new object[] { "just\"not\"right @example.com", new[] { errorMessage } },
                new object[] { "this is\"not\\allowed@example.com", new[] { errorMessage } },
                new object[] { "this\\ still\\\"not\\\\allowed@example.com", new[] { errorMessage } },
                new object[] { "john.doe@example..com", new[] { errorMessage } },
                new object[]
                {
                    new string('a', CommonConstants.MaxEmailUserPartLength + 1) + "@a.com",
                    new[] { CommonConstants.ErrorEmailTooLong }
                },
                new object[]
                {
                    "a@" + new string('a', CommonConstants.MaxEmailDomainPartLength - ".com".Length + 1) + ".com",
                    new[] { CommonConstants.ErrorEmailTooLong }
                }
            };
        }

        public static IEnumerable<object[]> ValidEmails()
        {
            return new object[][]
            {
                new object[] { "someemail@mail.com" },
                new object[] { "a@b.org" },
                new object[] { "someemail@test.ru" },
                new object[] { "simple@example.com" },
                new object[] { "very.common@example.com" },
                new object[] { "disposable.style.email.with+symbol@example.com" },
                new object[] { "other.email-with-hyphen@example.com" },
                new object[] { "fully-qualified-domain@example.com" },
                new object[] { "user.name+tag+sorting@example.com" },
                new object[] { "x@example.com" },
                new object[] { "example-indeed@strange-example.com" },
                new object[] { "example@s.example" },
                new object[] { "\" \"@example.org" },
                new object[] { "\"john..doe\"@example.org" },
                new object[] { new string('a', CommonConstants.MaxEmailUserPartLength) + "@a.com" },
                new object[] { "a@" + new string('a', CommonConstants.MaxEmailDomainPartLength - ".com".Length) + ".com" }
            };
        }
    }
}
