// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Runtime.Serialization;
using MGK.Acceptance;

namespace BSoft.BApp.Core.Exceptions
{
    public class BaseException : Exception
    {
        private const int _defaultStatusCode = 500;
        private const string _defaultCode = "general_error";
        private const string _defaultTitle = "General Error.";
        private const string _defaultMessage = "General error ocurred.";

        public BaseException()
            : this(null)
        {
        }

        public BaseException(string message)
            : this(null, null, message)
        {
        }
        
        public BaseException(string message, int statusCode)
            : this(null, null, message, statusCode)
        {
        }

        public BaseException(string code, string title, string message)
            : this(code, title, message, null, _defaultStatusCode)
        {
        }

        public BaseException(string code, string title, string message, int statusCode)
            : this(code, title, message, null, statusCode)
        {
        }

        public BaseException(string message, Exception innerException)
            : this(null, null, message, innerException, _defaultStatusCode)
        {
        }

        public BaseException(string message, Exception innerException, int statusCode)
            : this(null, null, message, innerException, statusCode)
        {
        }

        public BaseException(string code, string title, string message, Exception innerException)
            : this(null, null, message, innerException, _defaultStatusCode)
        {
        }

        public BaseException(string code, string title, string message, Exception innerException, int statusCode)
            : base(message ?? title ?? _defaultMessage, innerException)
        {
            Code = code ?? _defaultCode;
            Title = title ?? _defaultTitle;
            StatusCode = statusCode == 0 ? _defaultStatusCode : statusCode;
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Code = info.GetString(nameof(Code));
            Title = info.GetString(nameof(Title));
            StatusCode = info.GetInt32(nameof(StatusCode));
        }

        public string Code { get; }

        public string Title { get; }
        public int StatusCode { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Ensure.Value.IsNotNull(info, nameof(info));

            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(Title), Title);

            base.GetObjectData(info, context);
        }
    }
}
