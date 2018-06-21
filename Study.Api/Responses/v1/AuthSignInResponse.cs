namespace Study.Api.Responses.v1
{
    using Newtonsoft.Json;
    using Study.Common.Database.Entities;

    public class AuthSignInResponse
    {
        [JsonProperty("token")]
        public Token Token { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}