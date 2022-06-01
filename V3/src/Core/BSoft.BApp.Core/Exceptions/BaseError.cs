// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Diagnostics;
using System.Linq;
using MGK.Acceptance;

namespace BSoft.BApp.Core.Exceptions
{
    public class BaseError
    {
        public BaseError(string code, string title = null, string defaultMessage = null, int statusCode = 500)
        {
            Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(code, nameof(code));
            Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(title, nameof(title));
            Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(defaultMessage, nameof(defaultMessage));
            Ensure.Value.IsNotNull(statusCode, nameof(statusCode));

            Code = code;
            Title = title;
            Message = defaultMessage;
            StatusCode = statusCode;
        }

        public string Code { get; }

        public string Title { get; }

        public string Message { get; }

        public int StatusCode { get; }

        public BaseException Default(params object[] args) => Default(null, args);

        public BaseException Default(Exception innerException, params object[] args) => WithMessage(innerException, Message, args);

        public BaseException WithMessage(string message, params object[] args) => WithMessage(null, message, args);

        public BaseException WithMessage(Exception innerException, string message, params object[] args)
        {
            ValidateArguments(message, args);

            return new BaseException(Code, Title, FormatMessage(message, args) ?? Title, innerException, StatusCode);
        }

        public static explicit operator BaseException(BaseError error)
        {
            ValidateArguments(error.Message);

            return new BaseException(error.Code, error.Title, error.Message ?? error.Title, error.StatusCode);
        }

        public static explicit operator BaseError(BaseException exc)
        {
            return new BaseError(exc.Code, exc.Title, exc.Message, exc.StatusCode);
        }

        [Conditional("DEBUG")]
        private static void ValidateArguments(string message, params object[] args)
        {
            bool argumentsAreEmpty = args == null || !args.Any();

            if (message == null)
            {
                if (!argumentsAreEmpty)
                {
                    throw new ArgumentException(
                        "In order to use arguments you need to set default message (3rd parameter) in " +
                        $"{nameof(BaseError)} constructor or use {nameof(WithMessage)} overload.",
                        nameof(args));
                }
            }
            else if (argumentsAreEmpty)
            {
                try
                {
                    string.Format(message);
                }
                catch (FormatException)
                {
                    throw new ArgumentException(
                        "Error message has unmet parameters for the string.Format, " +
                        "please pass all required arguments for the error.",
                        nameof(message));
                }
            }
        }

        private static string FormatMessage(string format, params object[] args)
        {
            if (format == null)
            {
                return null;
            }

            if (args == null || !args.Any())
            {
                return format;
            }

            return string.Format(format, args);
        }
    }
}
