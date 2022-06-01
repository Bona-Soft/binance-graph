// Copyright (c) Zenfolio, Inc. All rights reserved.

using System.Collections.Generic;
using CommonConstants = Zenfolio.Common.Contract.Constants.Constants;

namespace Zenfolio.Common.Testing.TestData
{
    public static class PasswordTestData
    {
        public static IEnumerable<object[]> InvalidPassword()
        {
            return new object[][]
            {
                new object[] { "123456789", new string[] { CommonConstants.ErrorPasswordAtLeastOneUppercaseLetter } },
                new object[] { "abcdefghi", new string[] { CommonConstants.ErrorPasswordAtLeastOneUppercaseLetter, CommonConstants.ErrorPasswordAtLeastOneNumber } },
                new object[] { "ABCDEFFHI", new string[] { CommonConstants.ErrorPasswordAtLeastOneNumber } },
                new object[] { "!!!!!!!!!", new string[] { CommonConstants.ErrorPasswordAtLeastOneUppercaseLetter, CommonConstants.ErrorPasswordAtLeastOneNumber, CommonConstants.ErrorPasswordAtLeastOneUppercaseLetter } },
                new object[] { "aA1", new string[] { string.Format(CommonConstants.ErrorPasswordTooShort, CommonConstants.PasswordMinLength) } },
                new object[] { "a!A1", new string[] { string.Format(CommonConstants.ErrorPasswordTooShort, CommonConstants.PasswordMinLength) } },
                new object[] { "1a1111111", new string[] { CommonConstants.ErrorPasswordAtLeastOneUppercaseLetter } },
                new object[] { "1a!111111", new string[] { CommonConstants.ErrorPasswordAtLeastOneUppercaseLetter } },
                new object[] { "aAaaaaaaa", new string[] { CommonConstants.ErrorPasswordAtLeastOneNumber } },
                new object[] { "aA!aaaaaa", new string[] { CommonConstants.ErrorPasswordAtLeastOneNumber } },
                new object[] { null, new string[] { CommonConstants.ErrorPasswordIncorrect } },
                new object[] { "123", new string[] { string.Format(CommonConstants.ErrorPasswordTooShort, CommonConstants.PasswordMinLength) } },
                new object[] { "qwertyu", new string[] { string.Format(CommonConstants.ErrorPasswordTooShort, CommonConstants.PasswordMinLength) } },
                new object[] { "Duplicate", new string[] { CommonConstants.ErrorPasswordAtLeastOneNumber } },
                new object[] { "sdfgasdfhsg-=\0=-0-hdasghfghahdgfa7", new string[] { CommonConstants.ErrorPasswordAtLeastOneUppercaseLetter } },
                new object[] { "sdfgasdfhsg-=\0=-0-hdЁsghfghahdgfa7", new string[] { CommonConstants.ErrorPasswordInvalidSymbols } }
            };
        }

        public static IEnumerable<object[]> ValidPassword()
        {
            return new object[][]
            {
                new object[] { "1aA11111" },
                new object[] { "1aA!!!!!" },
                new object[] { "abcdefG1" },
                new object[] { "12345678aS" },
                new object[] { "abcd7efghW" },
                new object[] { "123456789012345678901234567890fD" },
                new object[] { "abcdefghijkLmnopqrstu\\vwxyz1" },
                new object[] { "a1B^@zzzzzzz;" },
                new object[] { "a1B!\"#$%&'()*+,-./:;<=>?@[] ^_`{|}~" },
                new object[] { "Winter_05!" },
                new object[] { "Abcdefg1\\" }
            };
        }

        public static IEnumerable<object[]> InvalidPasswordConfirmation()
        {
            return new object[][]
            {
                new object[] { "1", "2" },
                new object[] { "1111111a", "1111111A" },
                new object[] { "1aA!1111", "1aA!1112" },
                new object[] { "1aA!1111", "1aA!11112" },
                new object[] { "sdfgasdfhsg-=\0=-0-hdasghfghahdgfa7", "sd3dfhsgfhdasghfghahdgfa7" },
                new object[] { "Duplicate", "duplicate" },
                new object[] { "qwertyu", "asd" },
                new object[] { "123", "1234" },
                new object[] { null, string.Empty }
            };
        }

        public static IEnumerable<object[]> ValidPasswordConfirmation()
        {
            return new object[][]
            {
                new object[] { "Zxcvbnm1", "Zxcvbnm1" },
                new object[] { "Abcdefghi1", "Abcdefghi1" },
                new object[] { "Qwerty123", "Qwerty123" },
                new object[] { "qwertyU1", "qwertyU1" },
                new object[] { "Duplicate1", "Duplicate1" },
                new object[] { "~sdfgasdfhSg{'%0&#0$hdasghfghahdgfa7}", "~sdfgasdfhSg{'%0&#0$hdasghfghahdgfa7}" }
            };
        }

        public static IEnumerable<object[]> PasswordTooShort()
        {
            return new object[][]
            {
                new object[] { "1" },
                new object[] { "a" },
                new object[] { "1234567" },
                new object[] { "123 567" },
                new object[] { "1234qwe" }
            };
        }
    }
}
