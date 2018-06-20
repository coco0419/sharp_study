namespace Study.Api.Form
{
    using Newtonsoft.Json;

    public class ValidationError
    {
        private readonly string _field;
        private readonly string _message;

        public ValidationError(string field, string message)
        {
            _field = field;
            _message = message;
        }

        [JsonProperty("field")]
        public string Field => _field;

        [JsonProperty("message")]
        public string Message => _message;
    }
}
