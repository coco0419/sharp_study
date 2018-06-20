namespace Study.Api.Form
{
    using System;

    public class RequiredValidator<T> : IValidator where T : class
    {
        private readonly Func<T> _source;
        private readonly string _field;
        private readonly string _message;

        public RequiredValidator(Func<T> source, string field, string message)
        {
            _source = source;
            _field = field;
            _message = message;
        }

        public string Field => _field;

        public string Message => _message;

        public bool Valid()
        {
            var value = _source.Invoke();

            return value != null && !string.IsNullOrEmpty(value.ToString());
        }
    }
}
