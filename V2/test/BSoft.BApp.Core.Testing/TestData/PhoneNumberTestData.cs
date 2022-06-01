// Copyright (c) Zenfolio, Inc. All rights reserved.

using System.Collections.Generic;

namespace Zenfolio.Common.Testing.TestData
{
    public static class PhoneNumberTestData
    {
        public static IEnumerable<object[]> ValidPhoneNumbers()
        {
            return new object[][]
            {
                new object[] { "510 461 9285" },
                new object[] { "1 510-461-9285" },
                new object[] { "+1(234) 567 8912" },
                new object[] { "(782)2222222" },
                new object[] { "+1.321.654.3219" },
                new object[] { "+1 234 521 9999" },
                new object[] { "(234)567.9876" },
                new object[] { "1-234-567-8912" },
                new object[] { "+1.989.999.9999" },
                new object[] { "+1-989-999-9999" },
                new object[] { "+1 989 999 9999" }
            };
        }

        public static IEnumerable<object[]> InvalidPhoneNumbers()
        {
            return new object[][]
            {
                new object[] { "(792)2222222" },
                new object[] { "+2(555)5559874" },
                new object[] { "1-234-5671-8912" },
                new object[] { "123 567" },
                new object[] { "+1.999(999)9999" },
                new object[] { "1234qwe" },
                new object[] { "+1234h6789" },
                new object[] { "+1QW1227668" },
                new object[] { "-2822782627" },
                new object[] { "+2279928(1)" },
                new object[] { "+7(922)12345" },
                new object[] { "+1 33 999" },
                new object[] { "+18227826277898798" },
                new object[] { "+2279928(1)1112" },
                new object[] { "+792212345." },
                new object[] { "+1-33-999-999" }
            };
        }
    }
}
