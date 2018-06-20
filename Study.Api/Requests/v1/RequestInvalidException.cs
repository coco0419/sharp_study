namespace Study.Api.Requests.v1
{
    using System;
    using System.Collections.Generic;
    using Study.Api.Form;

    public class RequestInvalidException : Exception
    {
        private readonly IEnumerable<ValidationError> _errors;

        public RequestInvalidException(IEnumerable<ValidationError> errors) => _errors = errors;

        public IEnumerable<ValidationError> Errors => _errors;
    }
}
