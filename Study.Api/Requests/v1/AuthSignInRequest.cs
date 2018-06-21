namespace Study.Api.Requests.v1
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Study.Api.Form;

    public class AuthSignInRequest : ValidationRequest
    {
        public override IEnumerable<IValidator> Validators => new[]
        {
            new RequiredValidator<string>(() => LoginId, "login_id", "error.required"),
            new RequiredValidator<string>(() => Password, "password", "error.required")
        };

        [JsonProperty("login_id")]
        public string LoginId { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}