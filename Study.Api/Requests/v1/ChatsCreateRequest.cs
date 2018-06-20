namespace Study.Api.Requests.v1
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Study.Api.Form;

    public class ChatsCreateRequest : ValidationRequest
    {
        [JsonIgnore]
        public override IEnumerable<IValidator> Validators => new[]
        {
            new RequiredValidator<string>(() => Message, "message", "error.required")
        };

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
