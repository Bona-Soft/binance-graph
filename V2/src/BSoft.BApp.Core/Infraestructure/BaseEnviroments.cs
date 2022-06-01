// Copyright (c) BonaSoft, Inc. All rights reserved.

namespace BSoft.BApp.Core.Infraestructure
{
    public static class BaseEnviroments
    {
        public static class Development
        {
            public const string ErrorPath = "error_development";
        }

        public static class Local
        {
            public const string ErrorPath = "error_development";
        }

        public static class Test
        {
            public const string ErrorPath = "error_development";
        }

        public static class Staging
        {
            public const string ErrorPath = "error";
        }

        public static class Production
        {
            public const string ErrorPath = "error";
        }
    }
}
