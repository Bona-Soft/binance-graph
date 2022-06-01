// Copyright (c) BonaSoft, Inc. All rights reserved.

namespace BSoft.BApp.Core.Infraestructure
{
    public static class StatusCodes
    {
        public const int Status100_Continue = 100;
        public const int Status412_PreconditionFailed = 412;
        public const int Status413_PayloadTooLarge = 413;
        public const int Status413_RequestEntityTooLarge = 413;
        public const int Status414_RequestUriTooLong = 414;
        public const int Status414_UriTooLong = 414;
        public const int Status415_UnsupportedMediaType = 415;
        public const int Status416_RangeNotSatisfiable = 416;
        public const int Status416_RequestedRangeNotSatisfiable = 416;
        public const int Status417_ExpectationFailed = 417;
        public const int Status418_ImATeapot = 418;
        public const int Status419_AuthenticationTimeout = 419;
        public const int Status421_MisdirectedRequest = 421;
        public const int Status422_UnprocessableEntity = 422;
        public const int Status423_Locked = 423;
        public const int Status424_FailedDependency = 424;
        public const int Status426_UpgradeRequired = 426;
        public const int Status428_PreconditionRequired = 428;
        public const int Status429_TooManyRequests = 429;
        public const int Status431_RequestHeaderFieldsTooLarge = 431;
        public const int Status451_UnavailableForLegalReasons = 451;
        public const int Status500_InternalServerError = 500;
        public const int Status501_NotImplemented = 501;
        public const int Status502_BadGateway = 502;
        public const int Status503_ServiceUnavailable = 503;
        public const int Status504_GatewayTimeout = 504;
        public const int Status505_HttpVersionNotsupported = 505;
        public const int Status506_VariantAlsoNegotiates = 506;
        public const int Status507_InsufficientStorage = 507;
        public const int Status508_LoopDetected = 508;
        public const int Status411_LengthRequired = 411;
        public const int Status510_NotExtended = 510;
        public const int Status410_Gone = 410;
        public const int Status408_RequestTimeout = 408;
        public const int Status101_SwitchingProtocols = 101;
        public const int Status102_Processing = 102;
        public const int Status200_OK = 200;
        public const int Status201_Created = 201;
        public const int Status202_Accepted = 202;
        public const int Status203_NonAuthoritative = 203;
        public const int Status204_NoContent = 204;
        public const int Status205_ResetContent = 205;
        public const int Status206_PartialContent = 206;
        public const int Status207_MultiStatus = 207;
        public const int Status208_AlreadyReported = 208;
        public const int Status226_IMUsed = 226;
        public const int Status300_MultipleChoices = 300;
        public const int Status301_MovedPermanently = 301;
        public const int Status302_Found = 302;
        public const int Status303_SeeOther = 303;
        public const int Status304_NotModified = 304;
        public const int Status305_UseProxy = 305;
        public const int Status306_SwitchProxy = 306;
        public const int Status307_TemporaryRedirect = 307;
        public const int Status308_PermanentRedirect = 308;
        public const int Status400_BadRequest = 400;
        public const int Status401_Unauthorized = 401;
        public const int Status402_PaymentRequired = 402;
        public const int Status403_Forbidden = 403;
        public const int Status404_NotFound = 404;
        public const int Status405_MethodNotAllowed = 405;
        public const int Status406_NotAcceptable = 406;
        public const int Status407_ProxyAuthenticationRequired = 407;
        public const int Status409_Conflict = 409;
        public const int Status511_NetworkAuthenticationRequired = 511;
    }
}
