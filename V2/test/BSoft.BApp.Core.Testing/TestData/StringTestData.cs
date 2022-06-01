// Copyright (c) Zenfolio, Inc. All rights reserved.

using System.Collections.Generic;
using Zenfolio.Common.Extensions;
using CommonConstants = Zenfolio.Common.Contract.Constants.Constants;

namespace Zenfolio.Common.Testing.TestData
{
    public static class StringTestData
    {
        public static IEnumerable<object[]> ValidStrings(
            bool isRequired,
            int? minLength,
            int? maxLength)
        {
            var data = new List<object[]>();

            if (!isRequired)
            {
                data.Add(new object[] { null });
                data.Add(new object[] { string.Empty });
                data.Add(new object[] { " " });
            }

            int effectiveMinLength = UseMinLength(minLength) ? minLength.Value : 1;
            int effectiveMaxLength = UseMaxLength(maxLength) ? maxLength.Value : 100;

            data.Add(new object[] { new string('A', effectiveMinLength) });
            data.Add(new object[] { new string('B', (effectiveMinLength + effectiveMaxLength) / 2) });
            data.Add(new object[] { new string('C', effectiveMaxLength) });

            return data;
        }

        public static IEnumerable<object[]> InvalidStrings(
            bool isRequired,
            int? minLength,
            int? maxLength)
        {
            var data = new List<object[]>();

            if (isRequired)
            {
                data.Add(new object[] { null, CommonConstants.ErrorPropertyShouldNotBeEmpty });
                data.Add(new object[] { string.Empty, CommonConstants.ErrorPropertyShouldNotBeEmpty });
                data.Add(new object[] { " ", CommonConstants.ErrorPropertyShouldNotBeEmpty });
            }

            bool useMinLength = UseMinLength(minLength);
            bool useMaxLength = UseMaxLength(maxLength);

            if (useMinLength)
            {
                if (useMaxLength)
                {
                    string errorMessage = minLength == maxLength
                        ? CommonConstants.ErrorStringPropertyMustHaveExactLength
                            .FormatError(minLength.Value)
                        : CommonConstants.ErrorStringPropertyMustBeNotShorterAndNotLongerThan
                            .FormatError(minLength.Value, maxLength.Value);

                    data.Add(new object[] { new string('X', minLength.Value - 1), errorMessage });
                    data.Add(new object[] { new string('Y', maxLength.Value + 1), errorMessage });
                }
                else
                {
                    string errorMessage = CommonConstants.ErrorStringPropertyMustBeNotShorterThan
                        .FormatError(minLength.Value);

                    data.Add(new object[] { new string('X', minLength.Value - 1), errorMessage });
                }
            }
            else if (useMaxLength)
            {
                string errorMessage = CommonConstants.ErrorStringPropertyMustBeNotLongerThan
                    .FormatError(maxLength.Value);

                data.Add(new object[] { new string('Y', maxLength.Value + 1), errorMessage });
            }

            return data;
        }

        private static bool UseMinLength(int? minLength) => minLength.HasValue && minLength.Value > 0;

        private static bool UseMaxLength(int? maxLength) => maxLength.HasValue && maxLength.Value < int.MaxValue;
    }
}
