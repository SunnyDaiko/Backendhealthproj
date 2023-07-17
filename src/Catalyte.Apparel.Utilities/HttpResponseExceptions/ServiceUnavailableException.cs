﻿using System;

namespace Catalyte.Apparel.Utilities.HttpResponseExceptions
{
    /// <summary>
    /// A custom exception for service unavailable errors.
    /// </summary>
    [Serializable]
    public class ServiceUnavailableException : Exception, IHttpResponseException
    {
        public ServiceUnavailableException(string message)
        {
            Value = new(status: 503, error: "Service Unavailable", message: message);
        }
        public ServiceUnavailableException()
        {
        }
        public ServiceUnavailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public HttpResponseExceptionValue Value { get; set; }
    }
}