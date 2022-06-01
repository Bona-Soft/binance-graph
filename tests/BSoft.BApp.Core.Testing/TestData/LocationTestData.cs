// Copyright (c) Zenfolio, Inc. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using Zenfolio.Common.Extensions;
using CommonConstants = Zenfolio.Common.Contract.Constants.Constants;

namespace Zenfolio.Common.Testing.TestData
{
    public static class LocationTestData
    {
        public static IEnumerable<object[]> ValidCountry()
        {
            return new List<object[]>
            {
                new object[] { "US" },
                new object[] { "Canada" },
                new object[] { "New Zealand" }
            }.Concat(StringTestData.ValidStrings(true, CommonConstants.MinCountryLength, CommonConstants.MaxCountryLength));
        }

        public static IEnumerable<object[]> InvalidCountry()
        {
            return new List<object[]>
            {
                new object[] { "1", CommonConstants.ErrorInvalidCountry },
                new object[] { "US1", CommonConstants.ErrorInvalidCountry }
            }.Concat(StringTestData.InvalidStrings(true, CommonConstants.MinCountryLength, CommonConstants.MaxCountryLength));
        }

        public static IEnumerable<object[]> ValidState()
        {
            return new List<object[]>
            {
                new object[] { "CA" },
                new object[] { "CO" },
                new object[] { "NY" }
            }.Concat(StringTestData.ValidStrings(true, CommonConstants.MinStateLength, CommonConstants.MaxStateLength));
        }

        public static IEnumerable<object[]> InvalidState()
        {
            return new List<object[]>().Concat(StringTestData.InvalidStrings(
                true, CommonConstants.MinStateLength, CommonConstants.MaxStateLength));
        }

        public static IEnumerable<object[]> ValidCity()
        {
            return new List<object[]>
            {
                new object[] { "Los Angeles" },
                new object[] { "Chicago" },
                new object[] { "San Francisco" }
            }.Concat(StringTestData.ValidStrings(true, CommonConstants.MinCityLength, CommonConstants.MaxCityLength));
        }

        public static IEnumerable<object[]> InvalidCity()
        {
            return new List<object[]>().Concat(StringTestData.InvalidStrings(
                true, CommonConstants.MinCityLength, CommonConstants.MaxCityLength));
        }

        public static IEnumerable<object[]> ValidZipCode(bool fullAddress)
        {
            return new List<object[]>
            {
                new object[] { "4444" },
                new object[] { "55555" },
                new object[] { "666666" },
                new object[] { "7777777" }
            }.Concat(StringTestData.ValidStrings(fullAddress, CommonConstants.MinZipCodeLength, CommonConstants.MaxZipCodeLength));
        }

        public static IEnumerable<object[]> InvalidZipCode(bool fullAddress)
        {
            return new List<object[]>().Concat(StringTestData.InvalidStrings(
                fullAddress, CommonConstants.MinZipCodeLength, CommonConstants.MaxZipCodeLength));
        }

        public static IEnumerable<object[]> ValidStreetName(bool fullAddress)
        {
            return new List<object[]>
            {
                new object[] { "Los Robles" },
                new object[] { "Edison Way" },
                new object[] { "16th Ave" }
            }.Concat(StringTestData.ValidStrings(fullAddress, CommonConstants.MinStreetNameLength, CommonConstants.MaxStreetNameLength));
        }

        public static IEnumerable<object[]> InvalidStreetName(bool fullAddress)
        {
            return new List<object[]>().Concat(StringTestData.InvalidStrings(
                fullAddress, CommonConstants.MinStreetNameLength, CommonConstants.MaxStreetNameLength));
        }

        public static IEnumerable<object[]> ValidHouseNumber(bool fullAddress)
        {
            return new List<object[]>
            {
                new object[] { "3515" },
                new object[] { "23" },
                new object[] { "1" }
            }.Concat(StringTestData.ValidStrings(fullAddress, CommonConstants.MinHouseNumberLength, CommonConstants.MaxHouseNumberLength));
        }

        public static IEnumerable<object[]> InvalidHouseNumber(bool fullAddress)
        {
            return new List<object[]>().Concat(StringTestData.InvalidStrings(
                fullAddress, CommonConstants.MinHouseNumberLength, CommonConstants.MaxHouseNumberLength));
        }

        public static IEnumerable<object[]> ValidLongitude()
        {
            return new object[][]
            {
                new object[] { -180.0d },
                new object[] { -179.9d },
                new object[] { -1d },
                new object[] { 0d },
                new object[] { 1d },
                new object[] { 179.9d },
                new object[] { 180.0d }
            };
        }

        public static IEnumerable<object[]> InvalidLongitude()
        {
            string errorMessage = CommonConstants.ErrorInvalidCoordinateRange
                .FormatError(CommonConstants.MinLongitude, CommonConstants.MaxLongitude);

            return new object[][]
            {
                new object[] { -190.0d, errorMessage },
                new object[] { 190.0d, errorMessage },
                new object[] { -180.1d, errorMessage },
                new object[] { 180.1d, errorMessage }
            };
        }

        public static IEnumerable<object[]> ValidLatitude()
        {
            return new object[][]
            {
                new object[] { -90.0d },
                new object[] { -89.9d },
                new object[] { -1d },
                new object[] { 0d },
                new object[] { 1d },
                new object[] { 89.9d },
                new object[] { 90.0d }
            };
        }

        public static IEnumerable<object[]> InvalidLatitude()
        {
            string errorMessage = CommonConstants.ErrorInvalidCoordinateRange
                .FormatError(CommonConstants.MinLatitude, CommonConstants.MaxLatitude);

            return new object[][]
            {
                new object[] { -100.0d, errorMessage },
                new object[] { 100.0d, errorMessage },
                new object[] { -90.1d, errorMessage },
                new object[] { 90.1d, errorMessage }
            };
        }

        public static IEnumerable<object[]> LocationWithOverlaps()
        {
            return new object[][]
            {
                new object[] { -63.835230, 50.730615, -63.835230, 50.730615, 1 }, // exactly the same location
                new object[] { -63.836420, 50.730615, -63.835230, 50.730615, 1 }, // inside the round
                new object[] { -63.935230, 51.000615, -63.835230, 50.730615, 20 }, // inside the round
                new object[] { -62.835230, 50.730615, -63.835230, 50.730615, 44 }, // close to the round's border
                new object[] { -64.835230, 50.730615, -63.835230, 50.730615, 44 }, // close to the round's border
                new object[] { -63.835230, 49.730615, -63.835230, 50.730615, 70 }, // close to the round's border
                new object[] { -63.835230, 51.730615, -63.835230, 50.730615, 70 }, // close to the round's border
                new object[] { -122.2681103, 37.3464175, -122.1956233, 37.4770046, 10 } // PORT-17446
            };
        }

        public static IEnumerable<object[]> LocationWithoutOverlaps()
        {
            return new object[][]
            {
                new object[] { -62.83, 50.730615, -63.835230, 50.730615, 43 }, // a bit outside a round
                new object[] { -64.84, 50.730615, -63.835230, 50.730615, 43 }, // a bit outside a round
                new object[] { -63.835230, 49.72, -63.835230, 50.730615, 69 }, // a bit outside a round
                new object[] { -63.835230, 51.74, -63.835230, 50.730615, 69 }, // a bit outside a round
                new object[] { -70.835230, 51.74, -63.835230, 50.730615, 300 }, // far away from a round
                new object[] { -70.835230, 40.74, -63.835230, 50.730615, 700 }, // far away from a round
                new object[] { 63.835230, 51.74, -63.835230, 50.730615, 999 }, // other side of the world
                new object[] { -63.835230, -51.74, -63.835230, 50.730615, 999 } // other side of the world
            };
        }
    }
}
