using System;

namespace Catalyte.Apparel.Utilities.HttpResponseExceptions
{
    /// <summary>
    /// A custom exception for bad request errors.
    /// </summary>

    public class BadRequestException : Exception, IHttpResponseException
    {
        public BadRequestException(string message)
        {
            Value = new(status: 400, error: "Bad Request", message: message);
        }

        public BadRequestException()
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public HttpResponseExceptionValue Value { get; set; }
    }
}